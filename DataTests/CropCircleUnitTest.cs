/* CropCircleUnitTest.cs
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
    /// Tests if the Crop Circle class is functioning correctly
    /// </summary>
    public class CropCircleUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Crop Circle is served with berries 
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            CropCircle cc = new();
            Assert.True(cc.Berries);
        }

        /// <summary>
        /// Checks the default price
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            CropCircle cc = new();
            Assert.Equal((decimal)2.00, cc.Price);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            CropCircle cc = new();
            Assert.Equal(cc.Name, cc.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that when changes were made to the menu, the name of the menu stays same
        /// </summary>
        /// <param name="berries">If the Crop Circle is served with berries</param>
        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void NameShouldAlwaysBeCropCircle(bool berries)
        {
            CropCircle cc = new()
            {
                Berries = berries,
            };
            Assert.Equal("Crop Circle", cc.Name);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the price reflects the change
        /// </summary>
        /// <param name="berries">If the Crop Circle is served with berries</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(true, 2.00)]
        [InlineData(false, 2.00)]
        public void PriceShouldBeCorrect(bool berries, decimal price)
        {
            CropCircle cc = new()
            {
                Berries = berries,
            };

            Assert.Equal(price, cc.Price);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the calories reflect the change
        /// </summary>
        /// <param name="berries">If the Crop Circle is served with berries</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(true, (158 + 89))]
        [InlineData(false, (158 + 0))]
        public void CaloriesShouldBeCorrect(bool berries, uint calories)
        {
            CropCircle cc = new()
            {
                Berries = berries,
            };
            Assert.Equal(calories, cc.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crop Circle
        /// </summary>
        /// <param name="berries">If the Crop Circle is served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { })]
        [InlineData(false, new string[] { "Hold Berries" })]
        public void SpecialInstructionsRelfectsState(bool berries, string[] instructions)
        {
            CropCircle cc = new()
            {
                Berries = berries,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cc.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cc.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            CropCircle cc = new();
            Assert.IsAssignableFrom<IMenuItem>(cc);
            Assert.IsAssignableFrom<Side>(cc);
        }

        #endregion

        #region property changes

        /// <summary>
        /// Checks that changing Berries notifies other properties
        /// </summary>
        /// <param name="b">Berries</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingBerriesShouldNotifyPropertyChange(bool b, string propertyName)
        {
            CropCircle cc = new();
            Assert.PropertyChanged(cc, propertyName, () => { cc.Berries = b; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            CropCircle cc = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cc);
        }

        #endregion
    }
}
