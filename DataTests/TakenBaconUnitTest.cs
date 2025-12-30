/* TakenBaconUnitTest.cs
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
    /// Tests if the Taken Bacon class is functioning correctly
    /// </summary>
    public class TakenBaconUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that the default number of bacon strips for Taken Bacon is two
        /// </summary>
        [Fact]
        public void DefaultCountShouldBeTwoStrips()
        {
            TakenBacon tb = new();
            Assert.Equal(2u, tb.Count);
        }

        /// <summary>
        /// Checks the default price
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            TakenBacon tb = new();
            Assert.Equal((decimal)2.00, tb.Price);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            TakenBacon tb = new();
            Assert.Equal(tb.Name, tb.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that when changes were made to the menu, the name of the menu stays same
        /// </summary>
        /// <param name="count">The number of strips included</param>
        [Theory]
        [InlineData(2)]
        [InlineData(1)]
        [InlineData(12)]
        [InlineData(7)]
        public void NameShouldAlwaysBeTakenBacon(uint count)
        {
            TakenBacon tb = new()
            {
                Count = count,
            };
            Assert.Equal("Taken Bacon", tb.Name);
        }

        /// <summary>
        /// Checks that the number of bacon strips for Taken Bacon menu cannot be greater than 6 or less than 1,
        /// and is automatically set to 6 when try to set the value to a number greater than 6,
        /// or is automatically set to 1 when try to set the value to a number less than 1
        /// </summary>
        /// <param name="count">The number of strips included</param>
        /// <param name="expect">The expected count</param>
        [Theory]
        [InlineData(0, 1)]
        [InlineData(14, 6)]
        public void ShouldNotBeAbleToSetCountAboveSixOrBelowOne(uint count, uint expect)
        {
            TakenBacon tb = new()
            {
                Count = count,
            };
            Assert.Equal(expect, tb.Count);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the price reflects the change
        /// </summary>
        /// <param name="count">The number of strips included</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(2, (2 * 1.00))]
        [InlineData(1, (1 * 1.00))]
        [InlineData(5, (5 * 1.00))]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            TakenBacon tb = new()
            {
                Count = count,
            };
            Assert.Equal(price, tb.Price);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the calories reflect the change
        /// </summary>
        /// <param name="count">The number of strips included</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(2, (2 * 43))]
        [InlineData(1, (1 * 43))]
        [InlineData(5, (5 * 43))]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            TakenBacon tb = new()
            {
                Count = count,
            };
            Assert.Equal(calories, tb.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Taken Bacon
        /// </summary>
        /// <param name="count">The number of strips included</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, new string[] { })]
        [InlineData(5, new string[] { "5 strip(s)" })]
        public void SpecialInstructionsRelfectsState(uint count, string[] instructions)
        {
            TakenBacon tb = new()
            {
                Count = count,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, tb.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, tb.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            TakenBacon tb = new();
            Assert.IsAssignableFrom<IMenuItem>(tb);
            Assert.IsAssignableFrom<Side>(tb);
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
            TakenBacon tb = new();
            Assert.PropertyChanged(tb, propertyName, () => { tb.Count = count; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            TakenBacon tb = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(tb);
        }

        #endregion
    }
}
