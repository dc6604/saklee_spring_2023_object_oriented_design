/* FlyingSaucerUnitTest.cs
 * Modified by: Sak Lee
 */

using System.ComponentModel;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Unit tests for the FlyingSaucer class
    /// </summary>
    public class FlyingSaucerUnitTest
    {
        #region default values

        /// <summary>
        /// Checks that an unaltered Flying Saucer has 6 panacakes
        /// </summary>
        [Fact]
        public void DefaultStackSizeShouldBeSixPancakes()
        {
            FlyingSaucer fs = new();
            Assert.Equal(6u, fs.StackSize);
        }

        /// <summary>
        /// Checks that an unaltered Flying Saucer is served with syrup 
        /// </summary>
        [Fact]
        public void DefaultServedWithSyrup()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Syrup);
        }

        /// <summary>
        /// Checks that an unaltered Flying Saucer is served with berries
        /// </summary>
        [Fact]
        public void DefaultServedWithBerries()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.Berries);
        }

        /// <summary>
        /// Checks that an unmodified Flying Saucer is served with whipped cream
        /// </summary>
        [Fact]
        public void DefaultServedWithWhippedCream()
        {
            FlyingSaucer fs = new();
            Assert.True(fs.WhippedCream);
        }

        /// <summary>
        /// Checks the default price
        /// </summary>
        [Fact]
        public void DefaultPrice()
        {
            FlyingSaucer fs = new();
            Assert.Equal((decimal)8.50, fs.Price);
        }

        /// <summary>
        /// Checks the ToString() method
        /// </summary>
        [Fact]
        public void CheckToStringMethod()
        {
            FlyingSaucer fs = new();
            Assert.Equal(fs.Name, fs.ToString());
        }

        #endregion

        #region state changes

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the name does not change
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <remarks>There are more than 8 possible permutations of state, so we pick a subset to test against</remarks>
        [Theory]
        [InlineData(6, true, true, true)]
        [InlineData(0, true, true, true)]
        [InlineData(12, true, true, true)]
        [InlineData(6, true, false, true)]
        [InlineData(6, false, false, true)]
        [InlineData(3, true, false, false)]
        [InlineData(8, false, false, false)]
        [InlineData(11, true, true, false)]
        public void NameShouldAlwaysBeFlyingSaucer(uint stackSize, bool syrup, bool whippedCream, bool berries)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal("Flying Saucer", fs.Name);
        }

        /// <summary>
        /// This test verifies that a FlyingSaucer's StackSize cannot exceed 12, and 
        /// if it is attempted, the StackSize will be set to 12.
        /// </summary>
        [Fact]
        public void ShouldNotBeAbleToSetStackSizeAboveTwelve()
        {
            FlyingSaucer fs = new();
            fs.StackSize = 13;
            Assert.Equal(12u, fs.StackSize);
        }

        /// <summary>
        /// Checks that when changes were made to the menu, the price reflects the change
        /// </summary>
        /// <param name="stackSize">The number of pancakes included</param>
        /// <param name="price">The expected price</param>
        [Theory]
        [InlineData(6, ((0 * 0.75) + 8.50))]
        [InlineData(3, ((0 * 0.75) + 8.50))]
        [InlineData(1, ((0 * 0.75) + 8.50))]
        [InlineData(8, ((2 * 0.75) + 8.50))]
        [InlineData(12, ((6 * 0.75) + 8.50))]
        public void PriceShouldBeCorrect(uint stackSize, decimal price)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
            };
            Assert.Equal(price, fs.Price);
        }

        /// <summary>
        /// This test checks that even as the FlyingSaucer's state mutates, the calories reflect that state
        /// </summary>
        /// <param name="stackSize">The number of panacakes included</param>
        /// <param name="syrup">If the Flying Saucer will be served with syrup</param>
        /// <param name="whippedCream">If the Flying Saucer will be served with whipped cream</param>
        /// <param name="berries">If the Flying Saucer will be served with berries</param>
        /// <param name="calories">The expected calories, given the specified state</param>
        /// <remarks>
        /// We supply the expected calories as part of the InlineData - and we can supply it as a calculation.
        /// This allows for an easy visual inspection to verify that the expected calories are matched to inputs 
        /// </remarks>
        [Theory]
        [InlineData(6, true, true, true, 64 * 6 + 32 + 414 + 89)]
        [InlineData(0, true, true, true, 64 * 0 + 32 + 414 + 89)]
        [InlineData(12, true, true, true, 64 * 12 + 32 + 414 + 89)]
        [InlineData(6, true, false, true, 64 * 6 + 32 + 0 + 89)]
        [InlineData(6, false, false, true, 64 * 6 + 0 + 0 + 89)]
        [InlineData(3, true, false, false, 64 * 3 + 32 + 0 + 0)]
        [InlineData(8, false, false, false, 64 * 8 + 0 + 0 + 0)]
        [InlineData(11, true, true, false, 64 * 11 + 32 + 414 + 0)]
        public void CaloriesShouldBeCorrect(uint stackSize, bool syrup, bool whippedCream, bool berries, uint calories)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            Assert.Equal(calories, fs.Calories);

        }

        /// <summary>
        /// Checks that the special instructions reflect the current state of the Flying Saucer
        /// </summary>
        /// <param name="stackSize">The number of panacakes</param>
        /// <param name="syrup">If served with syrup</param>
        /// <param name="whippedCream">If served with whipped cream</param>
        /// <param name="berries">If served with berries</param>
        /// <param name="instructions">The expected special instructions</param>
        [Theory]
        [InlineData(6, true, true, true, new string[] {})]
        [InlineData(4, true, true, true, new string[] {"4 Pancake(s)"})]
        public void SpecialInstructionsRelfectsState(uint stackSize, bool syrup, bool whippedCream, bool berries, string[] instructions)
        {
            FlyingSaucer fs = new()
            {
                StackSize = stackSize,
                Syrup = syrup,
                WhippedCream = whippedCream,
                Berries = berries
            };
            // Check that all expected special instructions exist
            foreach(string instruction in instructions)
            {
                Assert.Contains(instruction, fs.SpecialInstructions);
            }
            // Check that no unexpected speical instructions exist
            Assert.Equal(instructions.Length, fs.SpecialInstructions.Count());
        }

        #endregion

        #region inheritance and interface

        /// <summary>
        /// Checks if the class can be casted into the assigned types
        /// </summary>
        [Fact]
        public void IsAssignableTo()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<IMenuItem>(fs);
            Assert.IsAssignableFrom<Entree>(fs);
        }

        #endregion

        #region property changes

        /// <summary>
        /// Checks that changing the count notifies other properties
        /// </summary>
        /// <param name="count">Count</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(6, "Price")]
        [InlineData(12, "Price")]
        [InlineData(6, "Calories")]
        [InlineData(12, "Calories")]
        public void ChangingCountShouldNotifyPropertyChange(uint count, string propertyName)
        {
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () => { fs.StackSize = count; });
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
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () => { fs.Syrup = b; });
        }

        /// <summary>
        /// Checks that changing WhippedCream notifies other properties
        /// </summary>
        /// <param name="b">WhippedCream</param>
        /// <param name="propertyName">Property to check</param>
        [Theory]
        [InlineData(true, "Calories")]
        [InlineData(false, "Calories")]
        public void ChangingWhippedCreamShouldNotifyPropertyChange(bool b, string propertyName)
        {
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () => { fs.WhippedCream = b; });
        }

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
            FlyingSaucer fs = new();
            Assert.PropertyChanged(fs, propertyName, () => { fs.Berries = b; });
        }

        /// <summary>
        /// Checks that INotifyPropertyChanged is implemented
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyChanged()
        {
            FlyingSaucer fs = new();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(fs);
        }

        #endregion
    }
}