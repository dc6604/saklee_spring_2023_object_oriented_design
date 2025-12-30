using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Tests the website functionalities
    /// </summary>
    public class WebsiteUnitTest
    {
        /// <summary>
        /// Tests the term search filter
        /// </summary>
        /// <param name="term">Seached term</param>
        /// <param name="count">Expected count</param>
        [Theory]
        [InlineData("saucer", 5)]
        [InlineData("s", 13)]
        [InlineData("s f", 4)]
        [InlineData("", 19)]
        public void TestingSearchTermFilter(string term, int count)
        {
            var model = new IndexModel();
            model.SearchTerms = term;
            model.OnGet();
            Assert.Equal(count, (model.Entrees.Count() + model.Sides.Count() + model.Drinks.Count()));
        }

        /// <summary>
        /// Tests the type search filter
        /// </summary>
        /// <param name="type">Seached menu type</param>
        /// <param name="count">Expected count</param>
        [Theory]
        [InlineData(null, 19)]
        [InlineData(new string[] { "Entree" }, 4)]
        [InlineData(new string[] { "Side" }, 6)]
        [InlineData(new string[] { "Drink" }, 9)]
        [InlineData(new string[] { "Entree", "Side" }, 10)]
        [InlineData(new string[] { "Entree", "Drink" }, 13)]
        [InlineData(new string[] { "Side", "Drink" }, 15)]
        [InlineData(new string[] { "Entree", "Side", "Drink" }, 19)]
        public void TestingMenuTypeFilter(string[] type, int count)
        {
            var model = new IndexModel();
            model.MenuType = type;
            model.OnGet();
            Assert.Equal(count, (model.Entrees.Count() + model.Sides.Count() + model.Drinks.Count()));
        }

        /// <summary>
        /// Tests the price search filter
        /// </summary>
        /// <param name="min">Set price minimum</param>
        /// <param name="max">Set price maximum</param>
        /// <param name="count">Expected count</param>
        [Theory]
        [ClassData(typeof(PriceFilterTestData))]
        public void TestingPriceFilter(decimal? min, decimal? max, int count)
        {
            var model = new IndexModel();
            model.PriceMin = min;
            model.PriceMax = max;
            model.OnGet();
            Assert.Equal(count, (model.Entrees.Count() + model.Sides.Count() + model.Drinks.Count()));
        }

        /// <summary>
        /// Tests the calories search filter
        /// </summary>
        /// <param name="min">Set calories minimum</param>
        /// <param name="max">Set calories maximum</param>
        /// <param name="count">Expected count</param>
        [Theory]
        [ClassData(typeof(CaloriesFilterTestData))]
        public void TestingCaloriesFilter(uint? min, uint? max, int count)
        {
            var model = new IndexModel();
            model.CaloriesMin = min;
            model.CaloriesMax = max;
            model.OnGet();
            Assert.Equal(count, (model.Entrees.Count() + model.Sides.Count() + model.Drinks.Count()));
        }
    }
}
