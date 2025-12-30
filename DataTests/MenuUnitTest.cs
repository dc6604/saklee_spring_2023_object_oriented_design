using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.DataTests
{
    /// <summary>
    /// Class for Menu unit test
    /// </summary>
    public class MenuUnitTest
    {
        #region default values

        /// <summary>
        /// Checks the default number of items in entrees
        /// </summary>
        [Fact]
        public void CheckTheDefaultCountsEntrees()
        {
            Assert.Equal(4, Menu.Entrees.Count());
        }

        /// <summary>
        /// Checks the default number of items in sides
        /// </summary>
        [Fact]
        public void CheckTheDefaultCountsSides()
        {
            Assert.Equal(6, Menu.Sides.Count());
        }

        /// <summary>
        /// Checks the default number of items in drinks
        /// </summary>
        [Fact]
        public void CheckTheDefaultCountsDrinks()
        {
            Assert.Equal(9, Menu.Drinks.Count());
        }

        /// <summary>
        /// Checks the default number of items in full menu
        /// </summary>
        [Fact]
        public void CheckTheDefaultCountsFullMenu()
        {
            Assert.Equal(13, Menu.FullMenu.Count());
        }

        /// <summary>
        /// Checks the items in the entrees
        /// </summary>
        [Fact]
        public void CheckTheDefaultEntrees()
        {
            List<IMenuItem> list = new List<IMenuItem>();
            list.Add(new FlyingSaucer());
            list.Add(new CrashedSaucer());
            list.Add(new OuterOmelette());
            list.Add(new LivestockMutilation());

            for (int i = 0; i < 4; i++)
            {
                Assert.Equal(list[i].Name, ((List<IMenuItem>)Menu.Entrees)[i].Name);
                Assert.Equal(list[i].Description, ((List<IMenuItem>)Menu.Entrees)[i].Description);
                Assert.Equal(list[i].Price, ((List<IMenuItem>)Menu.Entrees)[i].Price);
                Assert.Equal(list[i].Calories, ((List<IMenuItem>)Menu.Entrees)[i].Calories);
            }
        }

        /// <summary>
        /// Checks the items in the sides
        /// </summary>
        [Fact]
        public void CheckTheDefaultSides()
        {
            List<IMenuItem> list = new List<IMenuItem>();
            list.Add(new CropCircle());
            list.Add(new GlowingHaystack());
            list.Add(new TakenBacon());
            list.Add(new MissingLinks());
            list.Add(new EvisceratedEggs());
            list.Add(new YouAreToast());

            for (int i = 0; i < 6; i++)
            {
                Assert.Equal(list[i].Name, ((List<IMenuItem>)Menu.Sides)[i].Name);
                Assert.Equal(list[i].Description, ((List<IMenuItem>)Menu.Sides)[i].Description);
                Assert.Equal(list[i].Price, ((List<IMenuItem>)Menu.Sides)[i].Price);
                Assert.Equal(list[i].Calories, ((List<IMenuItem>)Menu.Sides)[i].Calories);
            }
        }

        /// <summary>
        /// Checks the items in the drinks
        /// </summary>
        [Fact]
        public void CheckTheDefaultDrinks()
        {
            List<IMenuItem> list = new List<IMenuItem>();
            list.Add(new LiquifiedVegetation());
            list.Add(new SaucerFuel());
            list.Add(new InorganicSubstance());

            for (int i = 0; i < 3; i++)
            {
                Assert.Equal(list[i].Name, ((List<IMenuItem>)Menu.Drinks)[3*i].Name);
                Assert.Equal(list[i].Description, ((List<IMenuItem>)Menu.Drinks)[3*i].Description);
                Assert.Equal(list[i].Price, ((List<IMenuItem>)Menu.Drinks)[3*i].Price);
                Assert.Equal(list[i].Calories, ((List<IMenuItem>)Menu.Drinks)[3*i].Calories);
            }
        }

        /// <summary>
        /// Checks the items in the full menu
        /// </summary>
        [Fact]
        public void CheckTheDefaultFullMenu()
        {
            List<IMenuItem> list = new List<IMenuItem>();
            list.Add(new FlyingSaucer());
            list.Add(new CrashedSaucer());
            list.Add(new OuterOmelette());
            list.Add(new LivestockMutilation());
            list.Add(new CropCircle());
            list.Add(new GlowingHaystack());
            list.Add(new TakenBacon());
            list.Add(new MissingLinks());
            list.Add(new EvisceratedEggs());
            list.Add(new YouAreToast());
            list.Add(new LiquifiedVegetation());
            list.Add(new SaucerFuel());
            list.Add(new InorganicSubstance());

            for (int i = 0; i < 13; i++)
            {
                Assert.Equal(list[i].Name, ((List<IMenuItem>)Menu.FullMenu)[i].Name);
                Assert.Equal(list[i].Description, ((List<IMenuItem>)Menu.FullMenu)[i].Description);
                Assert.Equal(list[i].Price, ((List<IMenuItem>)Menu.FullMenu)[i].Price);
                Assert.Equal(list[i].Calories, ((List<IMenuItem>)Menu.FullMenu)[i].Calories);
            }
        }

        #endregion
    }
}
