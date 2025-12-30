/* InorganicSubstanceUnitTest.cs
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
    /// Tests if the Inorganic Substance class is functioning properly
    /// </summary>
    public class InorganicSubstanceUnitTest
    {
        #region default values

        /// <summary>
        /// Checks if the default serving size is small
        /// </summary>
        [Fact]
        public void DefaultServingSizeIsSmall()
        {
            InorganicSubstance ios = new();
            Assert.True(ios.Size == ServingSize.Small);
        }

        /// <summary>
        /// Checks if the default setting is to serve with ice
        /// </summary>
        [Fact]
        public void DefaultServedWithIce()
        {
            InorganicSubstance ios = new();
            Assert.True(ios.Ice);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            InorganicSubstance ios = new();
            Assert.Equal(ios.Name, ios.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that when changes are made to the drink, the name of the drink stays the same
        /// </summary>
        /// <param name="ice">If the drink is served with ice</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeInorganicSubstance(bool ice)
        {
            InorganicSubstance ios = new();
            ios.Ice = ice;
            Assert.Equal("Inorganic Substance", ios.Name);
        }

        /// <summary>
        /// Checks that when changes are made to the drink, the price reflects the change
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(ServingSize.Small, 0.00)]
        [InlineData(ServingSize.Medium, 0.00)]
        [InlineData(ServingSize.Large, 0.00)]
        public void PriceShouldBeCorrect(ServingSize size, decimal price)
        {
            InorganicSubstance ios = new();
            ios.Size = size;
            Assert.Equal(price, ios.Price);
        }

        /// <summary>
        /// Checks that when changes are made to the drink, the calories reflect the change
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(ServingSize.Small, 0)]
        [InlineData(ServingSize.Medium, 0)]
        [InlineData(ServingSize.Large, 0)]
        public void CaloriesShouldBeCorrect(ServingSize size, uint calories)
        {
            InorganicSubstance ios = new();
            ios.Size = size;
            Assert.Equal(calories, ios.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the drink
        /// </summary>
        /// <param name="ice">If the drink is served with ice</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "No Ice" })]
        public void SpecialInstructionsRelfectsState(bool ice, string[] instructions)
        {
            InorganicSubstance ios = new();
            ios.Ice = ice;
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, ios.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, ios.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            InorganicSubstance ios = new();
            Assert.IsAssignableFrom<IMenuItem>(ios);
            Assert.IsAssignableFrom<Drink>(ios);
        }

        #endregion

        #region property changes

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            InorganicSubstance ios = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(ios);
        }

        #endregion
    }
}
