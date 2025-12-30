/* YouAreToastUnitTest.cs
 * Author: Sak Lee
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Tests if the You're Toast class is functioning correctly
    /// </summary>
    public class YouAreToastUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that the default number of toasts for You're Toast is two
        /// </summary>
        [Fact]
        public void DefaultCountShouldBeTwoToasts()
        {
            YouAreToast yat = new();
            Assert.Equal(2u, yat.Count);
        }

        /// <summary>
        /// Checks the default price
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            YouAreToast yat = new();
            Assert.Equal((decimal)2.00, yat.Price);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            YouAreToast yat = new();
            Assert.Equal(yat.Name, yat.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that when changes were made to the menu, the name of the menu stays same
        /// </summary>
        /// <param name="count">The number of toasts included</param>
        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(12)]
        public void NameShouldAlwaysBeYouAreToast(uint count)
        {
            YouAreToast yat = new()
            {
                Count = count,
            };
            Assert.Equal("You're Toast", yat.Name);
        }

        /// <summary>
        /// Checks that the number of toasts for You're Toast menu cannot be greater than 12 or less than 1,
        /// and is automatically set to 12 when try to set the value to a number greater than 12,
        /// or is automatically set to 1 when try to set the value to a number less than 1
        /// </summary>
        /// <param name="count">The number of toasts included</param>
        /// <param name="expect">The expected count</param>
        [Theory]
        [InlineData(0, 1)]
        [InlineData(15, 12)]
        public void ShouldNotBeAbleToSetCountAboveTwelveOrBelowOne(uint count, uint expect)
        {
            YouAreToast yat = new()
            {
                Count = count,
            };
            Assert.Equal(expect, yat.Count);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the price reflects the change
        /// </summary>
        /// <param name="count">The number of toasts included</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(2, (2 * 1.00))]
        [InlineData(1, (1 * 1.00))]
        [InlineData(12, (12 * 1.00))]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            YouAreToast yat = new()
            {
                Count = count,
            };
            Assert.Equal(price, yat.Price);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the calories reflect the change
        /// </summary>
        /// <param name="count">The number of toasts included</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(2, (2 * 100))]
        [InlineData(1, (1 * 100))]
        [InlineData(12, (12 * 100))]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            YouAreToast yat = new()
            {
                Count = count,
            };
            Assert.Equal(calories, yat.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Glowing Haystack
        /// </summary>
        /// <param name="count">The number of toasts included</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(7, new string[] { "7 slice(s)" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            YouAreToast yat = new()
            {
                Count = count,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, yat.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, yat.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            YouAreToast yat = new();
            Assert.IsAssignableFrom<IMenuItem>(yat);
            Assert.IsAssignableFrom<Side>(yat);
        }

        #endregion

        #region property changes

        /// <summary>
        /// Checks that changing the count notifies other properties
        /// </summary>
        /// <param name="count">Count</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(2, "Price")]
        [InlineData(6, "Price")]
        [InlineData(2, "Calories")]
        [InlineData(6, "Calories")]
        public void ChangingCountShouldNotifyPropertyChange(uint count, string propertyName)
        {
            YouAreToast yat = new();
            Assert.PropertyChanged(yat, propertyName, () => { yat.Count = count; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            YouAreToast yat = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(yat);
        }

        #endregion
    }
}
