/* LiquifiedVegetationUnitTest.cs
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
    /// Tests if the Liquified Vegetation class is functioning properly
    /// </summary>
    public class LiquifiedVegetationUnitTest
    {
        #region default values

        /// <summary>
        /// Checks if the default serving size is small
        /// </summary>
        [Fact]
        public void DefaultServingSizeIsSmall()
        {
            LiquifiedVegetation lv = new();
            Assert.True(lv.Size == ServingSize.Small);
        }

        /// <summary>
        /// Checks if the default setting is to serve with ice
        /// </summary>
        [Fact]
        public void DefaultServedWithIce()
        {
            LiquifiedVegetation lv = new();
            Assert.True(lv.Ice);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            LiquifiedVegetation lv = new();
            Assert.Equal(lv.Name, lv.ToString());
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
        public void NameShouldAlwaysBeLiquifiedVegetation(bool ice)
        {
            LiquifiedVegetation lf = new();
            lf.Ice = ice;
            Assert.Equal("Liquified Vegetation", lf.Name);
        }

        /// <summary>
        /// Checks that when changes are made to the drink, the price reflects the change
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(ServingSize.Small, 1.00)]
        [InlineData(ServingSize.Medium, 1.50)]
        [InlineData(ServingSize.Large, 2.00)]
        public void PriceShouldBeCorrect(ServingSize size, decimal price)
        {
            LiquifiedVegetation lv = new();
            lv.Size = size;
            Assert.Equal(price, lv.Price);
        }

        /// <summary>
        /// Checks that when changes are made to the drink, the calories reflect the change
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(ServingSize.Small, 72)]
        [InlineData(ServingSize.Medium, 144)]
        [InlineData(ServingSize.Large, 216)]
        public void CaloriesShouldBeCorrect(ServingSize size, uint calories)
        {
            LiquifiedVegetation lv = new();
            lv.Size = size;
            Assert.Equal(calories, lv.Calories);
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
            LiquifiedVegetation lv = new();
            lv.Ice = ice;
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lv.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, lv.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            LiquifiedVegetation lv = new();
            Assert.IsAssignableFrom<IMenuItem>(lv);
            Assert.IsAssignableFrom<Drink>(lv);
        }

        #endregion

        #region property changes

        /// <summary>
        /// Checks that changing the size notifies other properties
        /// </summary>
        /// <param name="size">Size</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(ServingSize.Small, "Price")]
        [InlineData(ServingSize.Medium, "Price")]
        [InlineData(ServingSize.Large, "Price")]
        [InlineData(ServingSize.Small, "Calories")]
        [InlineData(ServingSize.Medium, "Calories")]
        [InlineData(ServingSize.Large, "Calories")]
        public void ChangingSizeShouldNotifyPropertyChange(ServingSize size, string propertyName)
        {
            LiquifiedVegetation lv = new();
            Assert.PropertyChanged(lv, propertyName, () => { lv.Size = size; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            LiquifiedVegetation lv = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(lv);
        }

        #endregion
    }
}
