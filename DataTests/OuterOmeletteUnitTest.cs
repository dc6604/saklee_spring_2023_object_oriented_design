/* OuterOmeletteUnitTest.cs
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
    /// Tests if the Outer Omelette class is functioning correctly
    /// </summary>
    public class OuterOmeletteUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Outer Omelette is served with cheddar cheese
        /// </summary>
        [Fact]
        public void DefaultServedWithCheddarCheese()
        {
            OuterOmelette oo = new();
            Assert.True(oo.CheddarCheese);
        }

        /// <summary>
        /// Checks that an unaltered Outer Omelette is served with peppers
        /// </summary>
        [Fact]
        public void DefaultServedWithPeppers()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Peppers);
        }

        /// <summary>
        /// Checks that an unaltered Outer Omelette is served with mushrooms
        /// </summary>
        [Fact]
        public void DefaultServedWithMushrooms()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Mushrooms);
        }

        /// <summary>
        /// Checks that an unaltered Outer Omelette is served with tomatoes
        /// </summary>
        [Fact]
        public void DefaultServedWithTomatoes()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Tomatoes);
        }

        /// <summary>
        /// Checks that an unaltered Outer Omelette is served with onions
        /// </summary>
        [Fact]
        public void DefaultServedWithOnions()
        {
            OuterOmelette oo = new();
            Assert.True(oo.Onions);
        }

        /// <summary>
        /// Checks the default price
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            OuterOmelette oo = new();
            Assert.Equal((decimal)7.45, oo.Price);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            OuterOmelette oo = new();
            Assert.Equal(oo.Name, oo.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that when changes were made to the menu, the name of the menu stays same
        /// </summary>
        /// <param name="cheddarcheese">If the Outer Omelette is served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omelette is served with peppers</param>
        /// <param name="mushrooms">If the Outer Omelette is served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omelette is served with tomatoes</param>
        /// <param name="onions">If the Outer Omelette is served with onions</param>
        [Theory]
        [InlineData(true, true, true, true, true)]
        [InlineData(false, false, false, false, false)]
        [InlineData(true, false, false, false, false)]
        [InlineData(false, true, false, false, false)]
        [InlineData(false, false, true, false, false)]
        [InlineData(false, false, false, true, false)]
        [InlineData(false, false, false, false, true)]
        public void NameShouldAlwaysBeOuterOmelette(bool cheddarcheese, bool peppers, bool mushrooms, bool tomatoes, bool onions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarcheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions,
            };

            Assert.Equal("Outer Omelette", oo.Name);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the price reflects the change
        /// </summary>
        /// <param name="cheddarcheese">If the Outer Omelette is served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omelette is served with peppers</param>
        /// <param name="mushrooms">If the Outer Omelette is served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omelette is served with tomatoes</param>
        /// <param name="onions">If the Outer Omelette is served with onions</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(true, true, true, true, true, 7.45)]
        [InlineData(false, false, false, false, false, 7.45)]
        [InlineData(true, false, false, false, false, 7.45)]
        [InlineData(false, true, false, false, false, 7.45)]
        [InlineData(false, false, true, false, false, 7.45)]
        [InlineData(false, false, false, true, false, 7.45)]
        [InlineData(false, false, false, false, true, 7.45)]
        public void PriceShouldBeCorrect(bool cheddarcheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, decimal price)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarcheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions,
            };

            Assert.Equal(price, oo.Price);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the calories reflect the change
        /// </summary>
        /// <param name="cheddarcheese">If the Outer Omelette is served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omelette is served with peppers</param>
        /// <param name="mushrooms">If the Outer Omelette is served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omelette is served with tomatoes</param>
        /// <param name="onions">If the Outer Omelette is served with onions</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(true, true, true, true, true, (94 + 113 + 24 + 4 + 22 + 22))]
        [InlineData(false, false, false, false, false, (94 + 0 + 0 + 0 + 0 + 0))]
        [InlineData(true, false, false, false, false, (94 + 113 + 0 + 0 + 0 + 0))]
        [InlineData(false, true, false, false, false, (94 + 0 + 24 + 0 + 0 + 0))]
        [InlineData(false, false, true, false, false, (94 + 0 + 0 + 4 + 0 + 0))]
        [InlineData(false, false, false, true, false, (94 + 0 + 0 + 0 + 22 + 0))]
        [InlineData(false, false, false, false, true, (94 + 0 + 0 + 0 + 0 + 22))]
        public void CaloriesShouldBeCorrect(bool cheddarcheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, uint calories)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarcheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions,
            };

            Assert.Equal(calories, oo.Calories);
        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Outer Omelette
        /// </summary>
        /// <param name="cheddarcheese">If the Outer Omelette is served with cheddar cheese</param>
        /// <param name="peppers">If the Outer Omelette is served with peppers</param>
        /// <param name="mushrooms">If the Outer Omelette is served with mushrooms</param>
        /// <param name="tomatoes">If the Outer Omelette is served with tomatoes</param>
        /// <param name="onions">If the Outer Omelette is served with onions</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(true, true, true, true, true, new string[] { })]
        [InlineData(true, false, true, true, true, new string[] { "Hold Peppers" })]
        public void SpecialInstructionsRelfectsState(bool cheddarcheese, bool peppers, bool mushrooms, bool tomatoes, bool onions, string[] instructions)
        {
            OuterOmelette oo = new()
            {
                CheddarCheese = cheddarcheese,
                Peppers = peppers,
                Mushrooms = mushrooms,
                Tomatoes = tomatoes,
                Onions = onions,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, oo.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, oo.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            OuterOmelette oo = new();
            Assert.IsAssignableFrom<IMenuItem>(oo);
            Assert.IsAssignableFrom<Entree>(oo);
        }

        #endregion

        #region property changes

        /// <summary>
        /// Checks that changing CheddarCheese notifies other properties
        /// </summary>
        /// <param name="b">CheddarCheese</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingCheddarCheeseShouldNotifyPropertyChange(bool b, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () => { oo.CheddarCheese = b; });
        }

        /// <summary>
        /// Checks that changing Peppers notifies other properties
        /// </summary>
        /// <param name="b">Peppers</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingPeppersShouldNotifyPropertyChange(bool b, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () => { oo.Peppers = b; });
        }

        /// <summary>
        /// Checks that changing Mushrooms notifies other properties
        /// </summary>
        /// <param name="b">Mushrooms</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingMushroomsShouldNotifyPropertyChange(bool b, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () => { oo.Mushrooms = b; });
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
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () => { oo.Tomatoes = b; });
        }

        /// <summary>
        /// Checks that changing Onions notifies other properties
        /// </summary>
        /// <param name="b">Onions</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingOnionsShouldNotifyPropertyChange(bool b, string propertyName)
        {
            OuterOmelette oo = new();
            Assert.PropertyChanged(oo, propertyName, () => { oo.Onions = b; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            OuterOmelette oo = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(oo);
        }

        #endregion
    }
}
