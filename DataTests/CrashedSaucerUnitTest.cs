/* CrashedSaucerUnitTest.cs
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
    /// Tests if the Crashed Saucer class is functioning correctly
    /// </summary>
    public class CrashedSaucerUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that the default number of toasts for Crashed Saucer is two
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeTwoToasts()
        {
            CrashedSaucer cs = new();
            Assert.Equal(2u, cs.StackSize);
        }

        /// <summary>
        /// Checks that an unaltered Crashed Saucer is served with syrup 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Syrup);
        }

        /// <summary>
        /// Checks that an unaltered Crashed Saucer is served with butter
        /// </summary>
        [Fact]
        public void DefaultServedWithButter()
        {
            CrashedSaucer cs = new();
            Assert.True(cs.Butter);
        }

        /// <summary>
        /// Checks the default price
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            CrashedSaucer cs = new();
            Assert.Equal((decimal)6.45, cs.Price);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            CrashedSaucer cs = new();
            Assert.Equal(cs.Name, cs.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// Checks that when changes were made to the menu, the name of the menu stays same
        /// </summary>
        /// <param name="stackSize">The number of toasts included</param>
        /// <param name="syrup">If the Crashed Saucer is served with syrup</param>
        /// <param name="butter">If the Crashed Saucer is served with butter</param>
        [Theory]
        [InlineData(2, true, true)]
        [InlineData(2, false, false)]
        [InlineData(0, true, false)]
        [InlineData(5, false, true)]
        [InlineData(3, true, false)]
        [InlineData(4, false, false)]
        [InlineData(6, true, true)]
        [InlineData(1, false, true)]
        public void NameShouldAlwaysBeCrashedSaucer(uint stackSize, bool syrup, bool butter)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter,
            };
            Assert.Equal("Crashed Saucer", cs.Name);
        }

        /// <summary>
        /// Checks that the number of toasts for Crashed Saucer menu cannot exceed 6,
        /// and is automatically set to 6 when try to set the value to a number greater than 6.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveSix()
        {
            CrashedSaucer cs = new();
            cs.StackSize = 9;
            Assert.Equal(6u, cs.StackSize);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the price reflects the change
        /// </summary>
        /// <param name="stackSize">The number of toasts included</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(1, 6.45)]
        [InlineData(2, 6.45)]
        [InlineData(3, (6.45 + (1 * 1.50)))]
        [InlineData(5, (6.45 + (3 * 1.50)))]
        [InlineData(6, (6.45 + (4 * 1.50)))]
        public void PriceShouldBeCorrect(uint stackSize, decimal price)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
            };

            Assert.Equal(price, cs.Price);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the calories reflect the change
        /// </summary>
        /// <param name="stackSize">The number of toasts included</param>
        /// <param name="syrup">If the Crashed Saucer is served with syrup</param>
        /// <param name="butter">If the Crashed Saucer is served with butter</param>
        /// <param name="calories">The expected calories</param>
        [Theory]
        [InlineData(2, true, true, (2 * (149) + 52 + 35))]
        [InlineData(2, false, false, (2 * (149) + 0 + 0))]
        [InlineData(0, true, false, (0 * (149) + 52 + 0))]
        [InlineData(5, false, true, (5 * (149) + 0 + 35))]
        [InlineData(3, true, false, (3 * (149) + 52 + 0))]
        [InlineData(4, false, false, (4 * (149) + 0 + 0))]
        [InlineData(6, true, true, (6 * (149) + 52 + 35))]
        [InlineData(1, false, true, (1 * (149) + 0 + 35))]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool butter, uint calories)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter,
            };
            Assert.Equal(calories, cs.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Crashed Saucer
        /// </summary>
        /// <param name="stackSize">The number of toasts included</param>
        /// <param name="syrup">If the Crashed Saucer is served with syrup</param>
        /// <param name="butter">If the Crashed Saucer is served with butter</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(2, true, true, new string[] { })]
        [InlineData(5, true, true, new string[] { "5 slice(s)" })]
        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool butter, string[] instructions)
        {
            CrashedSaucer cs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                Butter = butter,
            };
            // Check that all expected special instructions exist
            foreach (string instruction in instructions)
            {
                Assert.Contains(instruction, cs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, cs.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<IMenuItem>(cs);
            Assert.IsAssignableFrom<Entree>(cs);
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
            CrashedSaucer cs = new();
            Assert.PropertyChanged(cs, propertyName, () => { cs.StackSize = count; });
        }

        /// <summary>
        /// Checks that changing Syrup notifies other properties
        /// </summary>
        /// <param name="b">Syrup</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingSyrupShouldNotifyPropertyChange(bool b, string propertyName)
        {
            CrashedSaucer cs = new();
            Assert.PropertyChanged(cs, propertyName, () => { cs.Syrup = b; });
        }

        /// <summary>
        /// Checks that changing Butter notifies other properties
        /// </summary>
        /// <param name="b">Butter</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingButterShouldNotifyPropertyChange(bool b, string propertyName)
        {
            CrashedSaucer cs = new();
            Assert.PropertyChanged(cs, propertyName, () => { cs.Butter = b; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            CrashedSaucer cs = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(cs);
        }

        #endregion
    }
}
