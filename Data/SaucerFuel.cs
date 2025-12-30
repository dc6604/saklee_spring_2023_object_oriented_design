/* SaucerFuel.cs
 * Author: Sak Lee
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Class for the drink Saucer Fuel
    /// </summary>
    public class SaucerFuel : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the name of the drink Saucer Fuel
        /// </summary>
        public override string Name 
        {
            get
            {
                if (Decaf) return "Decaf Saucer Fuel";
                else return "Saucer Fuel";
            } 
        }

        /// <summary>
        /// Property for the description of the drink Saucer Fuel
        /// </summary>
        public override string Description { get; } = "A steaming cup of coffee.";

        /// <summary>
        /// Private backing field for the Size property
        /// </summary>
        private ServingSize _size = ServingSize.Small;

        /// <summary>
        /// Serving size for the current instance of the drink
        /// </summary>
        public override ServingSize Size
        {
            get { return _size; }
            set
            {
                _size = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Property for whether to put caffeine in the current instance of the drink Saucer Fuel
        /// </summary>
        public bool Decaf { get; set; } = false;

        /// <summary>
        /// private backing field for the Cream property
        /// </summary>
        private bool _cream = false;

        /// <summary>
        /// Property for whether to put cream in the current instance of the drink Saucer Fuel
        /// </summary>
        public bool Cream 
        { 
            get { return _cream; } 
            set
            {
                _cream = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Property for the price of the current instance of the drink Saucer Fuel
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (Size == ServingSize.Small) return 1.00m;
                else if (Size == ServingSize.Medium) return 1.50m;
                else return 2.00m;
            }
        }

        /// <summary>
        /// Private backing field for the calories of the drink Saucer Fuel
        /// </summary>
        private uint _calories = 0;

        /// <summary>
        /// Property for the calories of the current instance of the drink Saucer Fuel
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == ServingSize.Small) _calories = 1;
                else if (Size == ServingSize.Medium) _calories = 2;
                else _calories = 3;
                if (Cream) _calories += 29;
                return _calories;
            }
        }

        /// <summary>
        /// Property for the special instructions for the current instance of the drink Saucer Fuel
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Cream) instructions.Add("With Cream");
                return instructions;
            }
        }
    }
}
