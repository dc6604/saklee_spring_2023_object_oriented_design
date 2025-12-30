/* Menu.cs
 * Author: Sak Lee
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Class for the menu
    /// </summary>
    public static class Menu
    {
        /// <summary>
        /// All entrees
        /// </summary>
        public static IEnumerable<IMenuItem> Entrees { get; set; } = new List<IMenuItem>();

        /// <summary>
        /// All sides
        /// </summary>
        public static IEnumerable<IMenuItem> Sides { get; set; } = new List<IMenuItem>();

        /// <summary>
        /// All drinks
        /// </summary>
        public static IEnumerable<IMenuItem> Drinks { get; set; } = new List<IMenuItem>();

        /// <summary>
        /// All menu
        /// </summary>
        public static IEnumerable<IMenuItem> FullMenu { get; set; } = new List<IMenuItem>();

        /// <summary>
        /// Menu type
        /// </summary>
        public static string[] MenuType
        {
            get => new string[]
            {
                "Entree",
                "Side",
                "Drink"
            };
        }

        /// <summary>
        /// Constructor for Menu class
        /// </summary>
        static Menu()
        {
            ((List<IMenuItem>)Entrees).Add(new FlyingSaucer());
            ((List<IMenuItem>)Entrees).Add(new CrashedSaucer());
            ((List<IMenuItem>)Entrees).Add(new OuterOmelette());
            ((List<IMenuItem>)Entrees).Add(new LivestockMutilation());

            ((List<IMenuItem>)Sides).Add(new CropCircle());
            ((List<IMenuItem>)Sides).Add(new GlowingHaystack());
            ((List<IMenuItem>)Sides).Add(new TakenBacon());
            ((List<IMenuItem>)Sides).Add(new MissingLinks());
            ((List<IMenuItem>)Sides).Add(new EvisceratedEggs());
            ((List<IMenuItem>)Sides).Add(new YouAreToast());

            ((List<IMenuItem>)Drinks).Add(new LiquifiedVegetation() { Size = ServingSize.Small });
            ((List<IMenuItem>)Drinks).Add(new LiquifiedVegetation() { Size = ServingSize.Medium });
            ((List<IMenuItem>)Drinks).Add(new LiquifiedVegetation() { Size = ServingSize.Large });
            ((List<IMenuItem>)Drinks).Add(new SaucerFuel() { Size = ServingSize.Small });
            ((List<IMenuItem>)Drinks).Add(new SaucerFuel() { Size = ServingSize.Medium });
            ((List<IMenuItem>)Drinks).Add(new SaucerFuel() { Size = ServingSize.Large });
            ((List<IMenuItem>)Drinks).Add(new InorganicSubstance() { Size = ServingSize.Small });
            ((List<IMenuItem>)Drinks).Add(new InorganicSubstance() { Size = ServingSize.Medium });
            ((List<IMenuItem>)Drinks).Add(new InorganicSubstance() { Size = ServingSize.Large });

            ((List<IMenuItem>)FullMenu).Add(new FlyingSaucer());
            ((List<IMenuItem>)FullMenu).Add(new CrashedSaucer());
            ((List<IMenuItem>)FullMenu).Add(new OuterOmelette());
            ((List<IMenuItem>)FullMenu).Add(new LivestockMutilation());
            ((List<IMenuItem>)FullMenu).Add(new CropCircle());
            ((List<IMenuItem>)FullMenu).Add(new GlowingHaystack());
            ((List<IMenuItem>)FullMenu).Add(new TakenBacon());
            ((List<IMenuItem>)FullMenu).Add(new MissingLinks());
            ((List<IMenuItem>)FullMenu).Add(new EvisceratedEggs());
            ((List<IMenuItem>)FullMenu).Add(new YouAreToast());
            ((List<IMenuItem>)FullMenu).Add(new LiquifiedVegetation());
            ((List<IMenuItem>)FullMenu).Add(new SaucerFuel());
            ((List<IMenuItem>)FullMenu).Add(new InorganicSubstance());
        }
            
    }
}
