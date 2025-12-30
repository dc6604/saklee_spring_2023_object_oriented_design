/* Order.cs
 * Author: Sak Lee
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Specialized;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Class for the order
    /// </summary>
    public class Order : ICollection<IMenuItem>, INotifyPropertyChanged, INotifyCollectionChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Collection change event declared
        /// </summary>
        public event NotifyCollectionChangedEventHandler? CollectionChanged;

        /// <summary>
        /// Private backing field for the order
        /// </summary>
        private List<IMenuItem> _order = new List<IMenuItem>();

        /// <summary>
        /// Property for the count of the item in the order
        /// </summary>
        public int Count { get { return _order.Count; } }

        /// <summary>
        /// Property to check whether the order is read-only
        /// </summary>
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Property for the total price of the items in the order
        /// </summary>
        public decimal Subtotal
        {
            get
            {
                decimal price = 0m;
                foreach (IMenuItem item in _order)
                {
                    price += item.Price;
                }
                return price;
            }
        }

        /// <summary>
        /// Private backing field for tax rate
        /// </summary>
        private decimal _taxRate;

        /// <summary>
        /// Property for the tax rate
        /// </summary>
        public decimal TaxRate 
        {
            get { return _taxRate; } 
            set
            {
                _taxRate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TaxRate"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tax"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Total"));
            } 
        }

        /// <summary>
        /// Property for the tax of the items in the order
        /// </summary>
        public decimal Tax { get => Subtotal * TaxRate; }

        /// <summary>
        /// Property for the total price of the items in the order after tax
        /// </summary>
        public decimal Total { get => Subtotal + Tax; }

        /// <summary>
        /// Private backing field for the order number
        /// </summary>
        private int _number = 1;

        /// <summary>
        /// Property for the order number
        /// </summary>
        public int Number { get => _number; }

        /// <summary>
        /// Private backing field for the time the order is placed at
        /// </summary>
        private DateTime _placedAt = DateTime.Now;

        /// <summary>
        /// Property for the time the order is placed at
        /// </summary>
        public DateTime PlacedAt { get => _placedAt; }

        /// <summary>
        /// Adds the given menu to the order
        /// </summary>
        /// <param name="menu">Given menu</param>
        public void Add(IMenuItem menu)
        {
            _order.Add(menu);
            menu.PropertyChanged += ItemChanged;
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, menu));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }

        /// <summary>
        /// Clears the order
        /// </summary>
        public void Clear()
        {
            _order.Clear();
            _number++;
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlacedAt)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
        }

        /// <summary>
        /// Checks whether the given menu is already in the order
        /// </summary>
        /// <param name="menu">Given menu</param>
        /// <returns>Whether the menu is in the order</returns>
        public bool Contains(IMenuItem menu)
        {
            if (_order.Contains(menu)) return true;
            else return false;
        }

        /// <summary>
        /// Copies the order list into an IMenuItem array
        /// </summary>
        /// <param name="menu">Array to which the list is to be copied</param>
        /// <param name="sp">Starting index</param>
        public void CopyTo(IMenuItem[] menu, int sp)
        {
            _order.CopyTo(menu, sp);
        }

        /// <summary>
        /// Removes the given menu from the order
        /// </summary>
        /// <param name="menu">Given menu</param>
        /// <returns>Whether the given menu was in the order</returns>
        public bool Remove(IMenuItem menu)
        {
            bool temp = _order.Contains(menu);
            int tempIndex = _order.IndexOf(menu);
            _order.Remove(menu);
            if (temp)
            {
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, menu, tempIndex));
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            menu.PropertyChanged -= ItemChanged;
            return temp;
        }

        /// <summary>
        /// Gets the enumerator for the order
        /// </summary>
        /// <returns>The enumerator</returns>
        IEnumerator<IMenuItem> IEnumerable<IMenuItem>.GetEnumerator()
        {
            return _order.GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator for the order
        /// </summary>
        /// <returns>The enumerator</returns>
        public System.Collections.IEnumerator GetEnumerator()
        {
            return ((System.Collections.IEnumerable)_order).GetEnumerator();
        }

        /// <summary>
        /// Custom event for item changed
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">EventArgs</param>
        public void ItemChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Price")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Subtotal)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Tax)));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Total)));
            }
        }

    }
}
