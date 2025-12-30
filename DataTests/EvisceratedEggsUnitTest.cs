/* EvisceratedEggsUnitTest.cs
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
    /// Tests if the Eviscerated Eggs class is functioning correctly
    /// </summary>
    public class EvisceratedEggsUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that the default number of eggs for Eviscerated Egg is two
        /// </summary>
        [Fact]
        public void DefaultCountShouldBeTwoEggs()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(2u, ee.Count);
        }

        /// <summary>
        /// Checks that an unaltered Eviscerated Eggs is served with over easy style. 
        /// </summary>
        [Fact]
        public void DefaultServedWithOverEasyStyle()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(EggStyle.OverEasy, ee.Style);
        }

        /// <summary>
        /// Checks the default price
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            EvisceratedEggs ee = new();
            Assert.Equal((decimal)2.00, ee.Price);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            EvisceratedEggs ee = new();
            Assert.Equal(ee.Name, ee.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that when changes were made to the menu, the name of the menu stays same 
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="style">How the egg should be cooked</param>
        [Theory]
        [InlineData(2, EggStyle.OverEasy)]
        [InlineData(1, EggStyle.HardBoiled)]
        [InlineData(6, EggStyle.Scrambled)]
        public void NameShouldAlwaysBeEvisceratedEggs(uint count, EggStyle style)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
                Style = style,
            };
            Assert.Equal("Eviscerated Eggs", ee.Name);
        }

        /// <summary>
        /// Checks that the number of eggs for Eviscerated Eggs menu cannot be greater than 6 or less than 1,
        /// and is automatically set to 6 when try to set the value to a number greater than 6,
        /// or is automatically set to 1 when try to set the value to a number less than 1
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="expect">The expected count</param>
        [Theory]
        [InlineData(0, 1)]
        [InlineData(11, 6)]
        public void ShouldNotBeAbleToSetCountAboveSixOrBelowOne(uint count, uint expect)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
            };
            Assert.Equal(expect, ee.Count);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the price reflects the change
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(2, (2 * 1.00))]
        [InlineData(1, (1 * 1.00))]
        [InlineData(6, (6 * 1.00))]
        public void PriceShouldBeCorrect(uint count, decimal price)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
            };
            Assert.Equal(price, ee.Price);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the calories reflect the change
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(2, (2 * 78))]
        [InlineData(1, (1 * 78))]
        [InlineData(6, (6 * 78))]
        public void CaloriesShouldBeCorrect(uint count, uint calories)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
            };
            Assert.Equal(calories, ee.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Eviscerated Eggs
        /// </summary>
        /// <param name="count">The number of eggs included</param>
        /// <param name="style">How the egg should be cooked</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, EggStyle.OverEasy, new string[] { "Over Easy" })]
        [InlineData(4, EggStyle.OverEasy, new string[] { "Over Easy", "4 egg(s)" })]
        [InlineData(2, EggStyle.Scrambled, new string[] { "Scrambled" })]
        public void SpecialInstructionsRelfectsState(uint count, EggStyle style, string[] instructions)
        {
            EvisceratedEggs ee = new()
            {
                Count = count,
                Style = style,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ee.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ee.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            EvisceratedEggs ee = new();
            Assert.IsAssignableFrom<IMenuItem>(ee);
            Assert.IsAssignableFrom<Side>(ee);
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
            EvisceratedEggs ee = new();
            Assert.PropertyChanged(ee, propertyName, () => { ee.Count = count; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            EvisceratedEggs ee = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ee);
        }

        #endregion
    }
}
