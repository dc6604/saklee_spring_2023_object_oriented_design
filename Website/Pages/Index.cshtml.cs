using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheFlyingSaucer.Data;
using System.Linq;

namespace Website.Pages
{
    /// <summary>
    /// Class for the page model of the index model
    /// </summary>
    public class IndexModel : PageModel
    {
        /// <summary>
        /// Constructor for Index model
        /// </summary>
        public IndexModel()
        {

        }

        /// <summary>
        /// Entrees list
        /// </summary>
        public IEnumerable<IMenuItem> Entrees { get; set; }

        /// <summary>
        /// Sides list
        /// </summary>
        public IEnumerable<IMenuItem> Sides { get; set; }

        /// <summary>
        /// Drinks list
        /// </summary>
        public IEnumerable<IMenuItem> Drinks { get; set; }

        /// <summary>
        /// Drink names
        /// </summary>
        public IEnumerable<string> DrinkNames { get; set; }

        /// <summary>
        /// Searched name
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchTerms { get; set; }

        /// <summary>
        /// Searched menu types
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string[] MenuType { get; set; }

        /// <summary>
        /// Searched minimum price
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMin { get; set; }

        /// <summary>
        /// Searched maximum price
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public decimal? PriceMax { get; set; }

        /// <summary>
        /// Searched minimum calories
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMin { get; set; }

        /// <summary>
        /// Searched maximum calories
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public uint? CaloriesMax { get; set; }

        /// <summary>
        /// OnGet method
        /// </summary>
        public void OnGet()
        {
            Entrees = Menu.Entrees;
            Sides = Menu.Sides;
            Drinks = Menu.Drinks;
            DrinkNames = new List<string>();

            if (SearchTerms != null)
            {
                IEnumerable<string> terms = SearchTerms.Split(" ");
                foreach (string term in terms)
                {
                    Entrees = Entrees.Where(entree => entree.Name.Contains(term, StringComparison.InvariantCultureIgnoreCase));
                    Sides = Sides.Where(side => side.Name.Contains(term, StringComparison.InvariantCultureIgnoreCase));
                    Drinks = Drinks.Where(drink => drink.Name.Contains(term, StringComparison.InvariantCultureIgnoreCase));
                }
            }

            if (MenuType != null && MenuType.Length != 0)
            {
                if (!(MenuType.Contains("Entree")))
                {
                    Entrees = new List<IMenuItem>();
                }
                if (!(MenuType.Contains("Side")))
                {
                    Sides = new List<IMenuItem>();
                }
                if (!(MenuType.Contains("Drink")))
                {
                    Drinks = new List<IMenuItem>();
                }
            }

            if (PriceMin != null || PriceMax != null)
            {
                if (PriceMin == null)
                {
                    Entrees = Entrees.Where(entree => entree.Price <= PriceMax);
                    Sides = Sides.Where(side => side.Price <= PriceMax);
                    Drinks = Drinks.Where(drink => drink.Price <= PriceMax);
                }
                else if (PriceMax == null)
                {
                    Entrees = Entrees.Where(entree => entree.Price >= PriceMin);
                    Sides = Sides.Where(side => side.Price >= PriceMin);
                    Drinks = Drinks.Where(drink => drink.Price >= PriceMin);
                }
                else
                {
                    Entrees = Entrees.Where(entree => entree.Price <= PriceMax && entree.Price >= PriceMin);
                    Sides = Sides.Where(side => side.Price <= PriceMax && side.Price >= PriceMin);
                    Drinks = Drinks.Where(drink => drink.Price <= PriceMax && drink.Price >= PriceMin);
                }
            }

            if (CaloriesMin != null || CaloriesMax != null)
            {
                if (CaloriesMin == null)
                {
                    Entrees = Entrees.Where(entree => entree.Calories <= CaloriesMax);
                    Sides = Sides.Where(side => side.Calories <= CaloriesMax);
                    Drinks = Drinks.Where(drink => drink.Calories <= CaloriesMax);
                }
                else if (CaloriesMax == null)
                {
                    Entrees = Entrees.Where(entree => entree.Calories >= CaloriesMin);
                    Sides = Sides.Where(side => side.Calories >= CaloriesMin);
                    Drinks = Drinks.Where(drink => drink.Calories >= CaloriesMin);
                }
                else
                {
                    Entrees = Entrees.Where(entree => entree.Calories <= CaloriesMax && entree.Calories >= CaloriesMin);
                    Sides = Sides.Where(side => side.Calories <= CaloriesMax && side.Calories >= CaloriesMin);
                    Drinks = Drinks.Where(drink => drink.Calories <= CaloriesMax && drink.Calories >= CaloriesMin);
                }
            }
        }
    }
}