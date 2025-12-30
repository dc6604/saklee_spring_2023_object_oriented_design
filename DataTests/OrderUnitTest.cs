/* OrderUnitTest.cs
 * Author: Sak Lee
 */

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Tests if the Order class is functioning properly
    /// </summary>
    public class OrderUnitTest
    {
        #region default value

        [Fact]
        public void CheckNumber()
        {
            Order order = new Order();
            Assert.Equal(1, order.Number);
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that menus get properly added on the order and the count is updated
        /// </summary>
        /// <param name="add">Whether the menu was added</param>
        /// <param name="count">The expected count</param>
        [Theory]
        [InlineData(true, 1)]
        [InlineData(false, 0)]
        public void CanAddCorrectMenuAndCount(bool add, int count)
        {
            Order order = new();
            FlyingSaucer fs = new FlyingSaucer();
            bool contain = order.Contains(fs);
            if (add)
            {
                order.Add(fs);
                contain = order.Contains(fs);
            }
            Assert.Equal(add, contain);
            Assert.Equal(count, order.Count);
        }

        /// <summary>
        /// Checks whether the correct prices are being calculated
        /// </summary>
        /// <param name="add1">Whether to add Flying Saucer menu</param>
        /// <param name="add2">Whether to add Missing Links side menu</param>
        /// <param name="add3">Whether to add Saucer Fuel drink</param>
        /// <param name="tax">Tax Rate</param>
        /// <param name="subtotal">The expected subtotal value</param>
        /// <param name="total">The expected total value</param>
        [Theory]
        [InlineData(true, true, true, 0.05, (8.50 + 2.00 + 1.00), ((8.50 + 2.00 + 1.00) + (8.50 + 2.00 + 1.00) * 0.05))]
        [InlineData(true, false, false, 0.05, (8.50 + 0.00 + 0.00), ((8.50 + 0.00 + 0.00) + (8.50 + 0.00 + 0.00) * 0.05))]
        [InlineData(false, true, false, 0.05, (0.00 + 2.00 + 0.00), ((0.00 + 2.00 + 0.00) + (0.00 + 2.00 + 0.00) * 0.05))]
        [InlineData(false, false, true, 0.08, (0.00 + 0.00 + 1.00), ((0.00 + 0.00 + 1.00) + (0.00 + 0.00 + 1.00) * 0.08))]
        [InlineData(true, false, true, 0.07, (8.50 + 0.00 + 1.00), ((8.50 + 0.00 + 1.00) + (8.50 + 0.00 + 1.00) * 0.07))]
        [InlineData(false, false, false, 0.05, (0.00 + 0.00 + 0.00), ((0.00 + 0.00 + 0.00) + (0.00 + 0.00 + 0.00) * 0.05))]
        public void ProduceCorrectPrices(bool add1, bool add2, bool add3, decimal tax, decimal subtotal, decimal total)
        {
            Order order = new();
            order.TaxRate = tax;
            FlyingSaucer fs = new();
            MissingLinks ml = new();
            SaucerFuel sf = new();
            if (add1) order.Add(fs);
            if (add2) order.Add(ml);
            if (add3) order.Add(sf);
            Assert.Equal(subtotal, order.Subtotal);
            Assert.Equal(total, order.Total);
        }

        #endregion

        #region events

        /// <summary>
        /// Checks whether the order class implements INotifyPropertyChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(order);
        }

        /// <summary>
        /// Checks whether a property change is properly notified
        /// </summary>
        [Fact]
        public void ChangingTaxRateShouldNotifyPropertyChange()
        {
            Order order = new Order();
            Assert.PropertyChanged(order, "TaxRate", () => { order.TaxRate = 0.15m; });
        }

        /// <summary>
        /// Checks whether the order class implements INotifyCollectionChanged
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyCollectionChanged()
        {
            Order order = new Order();
            Assert.IsAssignableFrom<INotifyCollectionChanged>(order);
        }

        /// <summary>
        /// Checks whether collection change is properly notified when adding an item to the collection
        /// </summary>
        [Fact]
        public void AddingItemShouldNotifyCollectionChange()
        {
            Order order = new Order();
            FlyingSaucer fs = new();
            MyAssert.NotifyCollectionChangedAdd(order, fs, () => { order.Add(fs); });
        }

        /// <summary>
        /// Check whether collection change is properly notified when removing an item from the collection
        /// </summary>
        [Fact]
        public void RemovingItemShouldNotifyCollectionChange()
        {
            Order order = new Order();
            FlyingSaucer fs = new();
            order.Add(fs);
            MyAssert.NotifyCollectionChangedRemove(order, fs, 0, () => { order.Remove(fs); });
        }

        #endregion
    }
}
