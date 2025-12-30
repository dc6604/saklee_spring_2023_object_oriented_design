/* MissingLinksUnitTest.cs
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
    /// Tests if the Missing Links class is functioning correctly
    /// </summary>
    public class MissingLinksUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that the default number of sausage links for Missing Links is two
        /// </summary>
        [Fact]
        public void DefaultCountShouldBeTwoLinks()
        {
            MissingLinks ml = new();
            Assert.Equal(2u, ml.Count);
        }

        /// <summary>
        /// Checks the default price
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            MissingLinks ml = new();
            Assert.Equal((decimal)2.00, ml.Price);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            MissingLinks ml = new();
            Assert.Equal(ml.Name, ml.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that when changes were made to the menu, the name of the menu stays same
        /// </summary>
        /// <param name="count">The number of sausage links included</param>
        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(8)]
        public void NameShouldAlwaysBeMissingLinks(uint count)
        {
            MissingLinks ml = new()
            {
                Count = count,
            };
            Assert.Equal("Missing Links", ml.Name);
        }

        /// <summary>
        /// Checks that the number of sausage links for Missing Links menu cannot be greater than 8 or less than 1,
        /// and is automatically set to 8 when try to set the value to a number greater than 8,
        /// or is automatically set to 1 when try to set the value to a number less than 1
        /// </summary>
        /// <param name="count">The number of sausage links included</param>
        /// <param name="expect">The expected count</param>
        [Theory]
        [InlineData(0, 1)]
        [InlineData(14, 8)]
        public void ShouldNotBeAbleToSetCountAboveEightOrBelowOne(uint count, uint expect)
        {
            MissingLinks ml = new()
            {
                Count = count,
            };
            Assert.Equal(expect, ml.Count);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the price reflects the change
        /// </summary>
        /// <param name="count">The number of sausage links included</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(2, (2 * 1.00))]
        [InlineData(1, (1 * 1.00))]
        [InlineData(8, (8 * 1.00))]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            MissingLinks ml = new()
            {
                Count = count,
            };

            Assert.Equal(price, ml.Price);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the calories reflect the change
        /// </summary>
        /// <param name="count">The number of sausage links included</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(2, (2 * 391))]
        [InlineData(1, (1 * 391))]
        [InlineData(8, (8 * 391))]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            MissingLinks ml = new()
            {
                Count = count,
            };

            Assert.Equal(calories, ml.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Missing Links
        /// </summary>
        /// <param name="count">The number of sausage links included</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(8, new string[] { "8 link(s)" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            MissingLinks ml = new()
            {
                Count = count,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ml.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ml.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            MissingLinks ml = new();
            Assert.IsAssignableFrom<IMenuItem>(ml);
            Assert.IsAssignableFrom<Side>(ml);
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
            MissingLinks ml = new();
            Assert.PropertyChanged(ml, propertyName, () => { ml.Count = count; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            MissingLinks ml = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ml);
        }

        #endregion
    }
}
