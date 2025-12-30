/* LivestockMutilationUnitTest.cs
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
    /// Tests if the Livestock Mutilation class is functioning correctly
    /// </summary>
    public class LivestockMutilationUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that the default number of biscuits for Livestock Mutilation is three
        /// </summary>
        [Fact]
        public void DefaultBiscuitsShouldBeThree()
        {
            LivestockMutilation lm = new();
            Assert.Equal(3u, lm.Biscuits);
        }

        /// <summary>
        /// Checks that an unaltered Livestock Mutilation is served with gravy 
        /// </summary>
        [Fact]
        public void DefaultServedWithGravy()
        {
            LivestockMutilation lm = new();
            Assert.True(lm.Gravy);
        }

        /// <summary>
        /// Checks the default price
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            LivestockMutilation lm = new();
            Assert.Equal((decimal)7.25, lm.Price);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            LivestockMutilation lm = new();
            Assert.Equal(lm.Name, lm.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that when changes were made to the menu, the name of the menu stays same
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation is served with gravy</param>
        [Theory]
        [InlineData(3, true)]
        [InlineData(3, false)]
        [InlineData(5, true)]
        [InlineData(8, false)]
        [InlineData(0, true)]
        [InlineData(1, false)]
        public void NameShouldAlwaysBeLivestockMutilation(uint biscuits, bool gravy)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy,
            };
            Assert.Equal("Livestock Mutilation", lm.Name);
        }

        /// <summary>
        /// Checks that the number of biscuits for Livestock Mutilation menu cannot exceed 8,
        /// and is automatically set to 8 when try to set the value to a number greater than 8.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetBiscuitsAboveEight()
        {
            LivestockMutilation lm = new();
            lm.Biscuits = 12;
            Assert.Equal(8u, lm.Biscuits);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the price reflects the change
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(3, ((0 * 1.00) + 7.25))]
        [InlineData(1, ((0 * 1.00) + 7.25))]
        [InlineData(8, ((5 * 1.00) + 7.25))]
        public void PriceShouldBeCorrect(uint biscuits, decimal price)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
            };
            Assert.Equal(price, lm.Price);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the calories reflect the change
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation is served with gravy</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(3, true, ((3 * 49) + 140))]
        [InlineData(3, false, ((3 * 49) + 0))]
        [InlineData(5, true, ((5 * 49) + 140))]
        [InlineData(8, false, ((8 * 49) + 0))]
        [InlineData(0, true, ((0 * 49) + 140))]
        [InlineData(1, false, ((1 * 49) + 0))]
        public void CaloriesShouldBeCorrect(uint biscuits, bool gravy, uint calories)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy,
            };
            Assert.Equal(calories, lm.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Livestock Mutilation
        /// </summary>
        /// <param name="biscuits">The number of biscuits included</param>
        /// <param name="gravy">If the Livestock Mutilation is served with gravy</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(3, true, new string[] { })]
        [InlineData(5, false, new string[] { "5 biscuit(s)", "Hold Gravy" })]
        public void SpecialInstructionsRelfectsState(uint biscuits, bool gravy, string[] instructions)
        {
            LivestockMutilation lm = new()
            {
                Biscuits = biscuits,
                Gravy = gravy,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, lm.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, lm.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<IMenuItem>(lm);
            Assert.IsAssignableFrom<Entree>(lm);
        }

        #endregion

        #region property changes

        /// <summary>
        /// Checks that changing the count notifies other properties
        /// </summary>
        /// <param name="count">Count</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(3, "Price")]
        [InlineData(8, "Price")]
        [InlineData(3, "Calories")]
        [InlineData(8, "Calories")]
        public void ChangingCountShouldNotifyPropertyChange(uint count, string propertyName)
        {
            LivestockMutilation lm = new();
            Assert.PropertyChanged(lm, propertyName, () => { lm.Biscuits = count; });
        }

        /// <summary>
        /// Checks that changing Gravy notifies other properties
        /// </summary>
        /// <param name="b">Gravy</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingGravyShouldNotifyPropertyChange(bool b, string propertyName)
        {
            LivestockMutilation lm = new();
            Assert.PropertyChanged(lm, propertyName, () => { lm.Gravy = b; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            LivestockMutilation lm = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(lm);
        }

        #endregion
    }
}
