/* MyAssert.cs
 * Author: Sak Lee
 */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Class for custom assert command for unit testing
    /// </summary>
    public static class MyAssert
    {
        /// <summary>
        /// Custom exception for collection change not triggered
        /// </summary>
        public class NotifyCollectionChangedNotTriggeredException: XunitException
        {
            public NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction expectedAction) : base($"Expected a NotifyCollectionChanged event with an action of {expectedAction} to be invoked, but saw none.") { }
        }

        /// <summary>
        /// Custom exception for collection change triggering wrong action
        /// </summary>
        public class NotifyCollectionChangedWrongActionException : XunitException
        {
            public NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction expectedAction, NotifyCollectionChangedAction actualAction) : base($"Expected a NotifyCollectionChanged event with an action of {expectedAction} to be invoked, but saw {actualAction}") { }
        }

        /// <summary>
        /// Custom exception for collection not adding properly
        /// </summary>
        public class NotifyCollectionChangedAddException : XunitException
        {
            public NotifyCollectionChangedAddException(object expected, object actual) : base($"Expected a NotifyCollectionChanged event with an action of Add and object {expected} but instead saw {actual}") { }
        }

        /// <summary>
        /// Custom exception for collection not removing properly
        /// </summary>
        public class NotifyCollectionChangedRemoveException : XunitException
        {
            public NotifyCollectionChangedRemoveException(object expectedItem, int expectedIndex, object actualItem, int actualIndex) : base($"Expected a NotifyCollectionChanged event with an action of Remove and object {expectedItem} at index {expectedIndex} but instead saw {actualItem} at index  {actualIndex}") { }
        }

        /// <summary>
        /// Method to check if an item is added to the collection properly
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="collection">The collection object implementing INotifyCollectionChanged</param>
        /// <param name="item">Item to be added</param>
        /// <param name="testCode">Given action</param>
        /// <exception cref="NotifyCollectionChangedWrongActionException">Exception</exception>
        /// <exception cref="NotifyCollectionChangedAddException">Exception</exception>
        /// <exception cref="NotifyCollectionChangedNotTriggeredException">Exception</exception>
        public static void NotifyCollectionChangedAdd<T>(INotifyCollectionChanged collection, T item, Action testCode)
        {
            bool notifySucceeded = false;

            NotifyCollectionChangedEventHandler handler = (sender, args) =>
            {
                if (args.Action != NotifyCollectionChangedAction.Add)
                {
                    throw new NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction.Add, args.Action);
                }
                if (args.NewItems?.Count != 1)
                {
                    throw new NotifyCollectionChangedAddException(item, args.NewItems);
                }
                if (!args.NewItems[0].Equals(item))
                {
                    throw new NotifyCollectionChangedAddException(item, args.NewItems[0]);
                }
                notifySucceeded = true;
            };
            collection.CollectionChanged += handler;
            try
            {
                testCode();
                if (!notifySucceeded)
                {
                    throw new NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction.Add);
                }
            }
            finally
            {
                collection.CollectionChanged -= handler;
            }
        }

        /// <summary>
        /// Method to check if an item is removed from the collection properly
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="collection">The collection object implementing INotifyCollectionChanged</param>
        /// <param name="item">Item to be removed</param>
        /// <param name="index">Index of the item to be removed</param>
        /// <param name="testCode">Given action</param>
        /// <exception cref="NotifyCollectionChangedWrongActionException">Exception</exception>
        /// <exception cref="NotifyCollectionChangedRemoveException">Exception</exception>
        /// <exception cref="NotifyCollectionChangedNotTriggeredException">Exception</exception>
        public static void NotifyCollectionChangedRemove<T>(INotifyCollectionChanged collection, T item, int index, Action testCode)
        {
            bool succeeded = false;

            NotifyCollectionChangedEventHandler handler = (sender, args) =>
            {
                if (args.Action != NotifyCollectionChangedAction.Remove)
                {
                    throw new NotifyCollectionChangedWrongActionException(NotifyCollectionChangedAction.Remove, args.Action);
                }
                if (args.OldItems?.Count != 1 || !(args.OldItems[0].Equals(item)) || args.OldStartingIndex != index)
                {
                    throw new NotifyCollectionChangedRemoveException(item, index, args.OldItems, args.OldStartingIndex);
                }
                succeeded = true;
            };
            collection.CollectionChanged += handler;
            try
            {
                testCode();
                if (!succeeded)
                {
                    throw new NotifyCollectionChangedNotTriggeredException(NotifyCollectionChangedAction.Remove);
                }
            }
            finally
            {
                collection.CollectionChanged -= handler;
            }
        }
    }
}
