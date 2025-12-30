/* SaucerFuelUnitTest.cs
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
    /// Tests if the Saucer Fuel class is functioning properly
    /// </summary>
    public class SaucerFuelUnitTest
    {
        #region default values

        /// <summary>
        /// Checks if the default serving size is small
        /// </summary>
        [Fact]
        public void DefaultServingSizeIsSmall()
        {
            SaucerFuel sf = new();
            Assert.True(sf.Size == ServingSize.Small);
        }

        /// <summary>
        /// Checks if the default setting is to not serve a decaf
        /// </summary>
        [Fact]
        public void DefaultServedNotDecaf()
        {
            SaucerFuel sf = new();
            Assert.False(sf.Decaf);
        }

        /// <summary>
        /// Checks if the default setting is to not serve with cream
        /// </summary>
        [Fact]
        public void DefaultServedNotWithCream()
        {
            SaucerFuel sf = new();
            Assert.False(sf.Cream);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            SaucerFuel sf = new();
            Assert.Equal(sf.Name, sf.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that when changes are made to the drink, the name of the drink changes accordingly
        /// </summary>
        /// <param name="decaf">If the drink is served as a decaf</param>
        /// <param name="cream">If the drink is served with cream</param>
        /// <param name="name">The expected name of the drink</param>
        [Theory]
        [InlineData(true, true, "Decaf Saucer Fuel")]
        [InlineData(false, true, "Saucer Fuel")]
        [InlineData(true, false, "Decaf Saucer Fuel")]
        [InlineData(false, false, "Saucer Fuel")]
        public void NameShouldChangeAccordingToDecafStatus(bool decaf, bool cream, string name)
        {
            SaucerFuel sf = new();
            sf.Decaf = decaf;
            sf.Cream = cream;
            Assert.Equal(name, sf.Name);
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
            SaucerFuel sf = new();
            sf.Size = size;
            Assert.Equal(price, sf.Price);
        }

        /// <summary>
        /// Checks that when changes are made to the drink, the calories reflect the change
        /// </summary>
        /// <param name="size">The size of the drink</param>
        /// <param name="cream">Whether the drink is served with cream</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(ServingSize.Small, true, (1+29))]
        [InlineData(ServingSize.Medium, true, (2+29))]
        [InlineData(ServingSize.Large, true, (3+29))]
        [InlineData(ServingSize.Small, false, 1)]
        [InlineData(ServingSize.Medium, false, 2)]
        [InlineData(ServingSize.Large, false, 3)]
        public void CaloriesShouldBeCorrect(ServingSize size, bool cream, uint calories)
        {
            SaucerFuel sf = new();
            sf.Size = size;
            sf.Cream = cream;
            Assert.Equal(calories, sf.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the drink
        /// </summary>
        /// <param name="cream">Whether the drink is served with cream</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, new string[] { "With Cream" })]
        [InlineData(false, new string[] { })]
        public void SpecialInstructionsRelfectsState(bool cream, string[] instructions)
        {
            SaucerFuel sf = new();
            sf.Cream = cream;
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, sf.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, sf.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            SaucerFuel sf = new();
            Assert.IsAssignableFrom<IMenuItem>(sf);
            Assert.IsAssignableFrom<Drink>(sf);
        }

        #endregion

        #region property changes

        /// <summary>
        /// Checks that changing the serving size notifies other properties
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
        public void ChangingCountShouldNotifyPropertyChange(ServingSize size, string propertyName)
        {
            SaucerFuel sf = new();
            Assert.PropertyChanged(sf, propertyName, () => { sf.Size = size; });
        }

        /// <summary>
        /// Checks that changing Cream notifies other properties
        /// </summary>
        /// <param name="b">Cream</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingCreamShouldNotifyPropertyChange(bool b, string propertyName)
        {
            SaucerFuel sf = new();
            Assert.PropertyChanged(sf, propertyName, () => { sf.Cream = b; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            SaucerFuel sf = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(sf);
        }

        #endregion
    }
}
