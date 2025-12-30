/* GlowingHaystackUnitTest.cs
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
    /// Tests if the Glowin Haystack class is functioning correctly
    /// </summary>
    public class GlowingHaystackUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Glowing Haystack is served with green chili sauce 
        /// </summary>
        [Fact]
        public void DefaultServedWithGreenChiliSauce()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.GreenChileSauce);
        }

        /// <summary>
        /// Checks that an unaltered Glowing Haystack is served with sour cream 
        /// </summary>
        [Fact]
        public void DefaultServedWithSourCream()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.SourCream);
        }

        /// <summary>
        /// Checks that an unaltered Glowing Haystack is served with tomatoes 
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            GlowingHaystack gh = new();
            Assert.True(gh.Tomatoes);
        }

        /// <summary>
        /// Checks the default price
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            GlowingHaystack gh = new();
            Assert.Equal((decimal)2.00, gh.Price);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            GlowingHaystack gh = new();
            Assert.Equal(gh.Name, gh.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that when changes were made to the menu, the name of the menu stays same
        /// </summary>
        /// <param name="greenchilisauce">If the Glowing Haystack is served with green chili sauce</param>
        /// <param name="sourcream">If the Glowing Haystack is served with sour cream</param>
        /// <param name="tomatoes">If the Glowing Haystack is served with tomatoes</param>
        [Theory]
        [InlineData(true, true, true)]
        [InlineData(false, false, false)]
        [InlineData(true, false, false)]
        [InlineData(false, true, false)]
        [InlineData(false, false, true)]
        public void NameShouldAlwaysBeGlowingHaystack(bool greenchilisauce, bool sourcream, bool tomatoes)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenchilisauce,
                SourCream = sourcream,
                Tomatoes = tomatoes,
            };
            Assert.Equal("Glowing Haystack", gh.Name);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the price reflects the change
        /// </summary>
        /// <param name="greenchilisauce">If the Glowing Haystack is served with green chili sauce</param>
        /// <param name="sourcream">If the Glowing Haystack is served with sour cream</param>
        /// <param name="tomatoes">If the Glowing Haystack is served with tomatoes</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(true, true, true, 2.00)]
        [InlineData(false, false, false, 2.00)]
        [InlineData(true, false, false, 2.00)]
        [InlineData(false, true, false, 2.00)]
        [InlineData(false, false, true, 2.00)]
        public void PriceShouldBeCorrect(bool greenchilisauce, bool sourcream, bool tomatoes, decimal price)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenchilisauce,
                SourCream = sourcream,
                Tomatoes = tomatoes,
            };

            Assert.Equal(price, gh.Price);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the calories reflect the change
        /// </summary>
        /// <param name="greenchilisauce">If the Glowing Haystack is served with green chili sauce</param>
        /// <param name="sourcream">If the Glowing Haystack is served with sour cream</param>
        /// <param name="tomatoes">If the Glowing Haystack is served with tomatoes</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(true, true, true, (470 + 15 + 23 + 22))]
        [InlineData(false, false, false, (470 + 0 + 0 + 0))]
        [InlineData(true, false, false, (470 + 15 + 0 + 0))]
        [InlineData(false, true, false, (470 + 0 + 23 + 0))]
        [InlineData(false, false, true, (470 + 0 + 0 + 22))]
        public void CaloriesShouldBeCorrect(bool greenchilisauce, bool sourcream, bool tomatoes, uint calories)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenchilisauce,
                SourCream = sourcream,
                Tomatoes = tomatoes,
            };

            Assert.Equal(calories, gh.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Glowing Haystack
        /// </summary>
        /// <param name="greenchilisauce">If the Glowing Haystack is served with green chili sauce</param>
        /// <param name="sourcream">If the Glowing Haystack is served with sour cream</param>
        /// <param name="tomatoes">If the Glowing Haystack is served with tomatoes</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, new string[] { })]
        [InlineData(false, false, true, new string[] { "Hold Green Chili Sauce", "Hold Sour Cream" })]
        public void SpecialInstructionsRelfectsState(bool greenchilisauce, bool sourcream, bool tomatoes, string[] instructions)
        {
            GlowingHaystack gh = new()
            {
                GreenChileSauce = greenchilisauce,
                SourCream = sourcream,
                Tomatoes = tomatoes,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, gh.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, gh.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<IMenuItem>(gh);
            Assert.IsAssignableFrom<Side>(gh);
        }

        #endregion

        #region property changes

        /// <summary>
        /// Checks that changing SourCream notifies other properties
        /// </summary>
        /// <param name="b">SourCream</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingSourCreamShouldNotifyPropertyChange(bool b, string propertyName)
        {
            GlowingHaystack gh = new();
            Assert.PropertyChanged(gh, propertyName, () => { gh.SourCream = b; });
        }

        /// <summary>
        /// Checks that changing GreenChileSauce notifies other properties
        /// </summary>
        /// <param name="b">GreenChileSauce</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingGreenChileSauceShouldNotifyPropertyChange(bool b, string propertyName)
        {
            GlowingHaystack gh = new();
            Assert.PropertyChanged(gh, propertyName, () => { gh.GreenChileSauce = b; });
        }

        /// <summary>
        /// Checks that changing Tomatoes notifies other properties
        /// </summary>
        /// <param name="b">Tomatoes</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingTomatoesShouldNotifyPropertyChange(bool b, string propertyName)
        {
            GlowingHaystack gh = new();
            Assert.PropertyChanged(gh, propertyName, () => { gh.Tomatoes = b; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            GlowingHaystack gh = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(gh);
        }

        #endregion
    }
}
