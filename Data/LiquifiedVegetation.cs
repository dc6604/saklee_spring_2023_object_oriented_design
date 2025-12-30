/* LiquifiedVegetation.cs
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
    /// Class for the drink Liquified Vegetation
    /// </summary>
    public class LiquifiedVegetation : Drink, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the name of the drink Liquified Vegetation
        /// </summary>
        public override string Name { get; } = "Liquified Vegetation";

        /// <summary>
        /// Property for the description of the drink Liquified Vegetation
        /// </summary>
        public override string Description { get; } = "A cold glass of blended vegetable juice.";

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
        /// Property for whether to put ice in the current instance of the drink Liquified Vegetation
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// Property for the price of the current instance of the drink Liquified Vegetation
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
        /// Property for the calories of the current instance of the drink Liquified Vegetation
        /// </summary>
        public override uint Calories
        {
            get
            {
                if (Size == ServingSize.Small) return 72;
                else if (Size == ServingSize.Medium) return 144;
                else return 216;
            }
        }

        /// <summary>
        /// Property for the special instructions for the current instance of the drink Liquified Vegetation
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Ice) instructions.Add("No Ice");
                return instructions;
            }
        }
    }
}
