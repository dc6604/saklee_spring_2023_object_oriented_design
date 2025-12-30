/* GlowingHaystack.cs
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
    /// Class for the side menu Glowing Haystack
    /// </summary>
    public class GlowingHaystack : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the name of the side menu Glowing Haystack
        /// </summary>
        public override string Name { get; } = "Glowing Haystack";

        /// <summary>
        /// Property for the description of the side menu Glowing Haystack
        /// </summary>
        public override string Description { get; } = "Hash browns smothered in green chile sauce, sour cream, and topped with tomatoes.";

        /// <summary>
        /// Private backing field for the SourCream property
        /// </summary>
        private bool _sourCream = true;

        /// <summary>
        /// Property for whether to put sour cream on the current instance of the side menu Glowing Haystack
        /// </summary>
        public bool SourCream
        {
            get { return _sourCream; }
            set
            {
                _sourCream = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Private backing field for the GreenChileSauce property
        /// </summary>
        private bool _greenChileSauce = true;

        /// <summary>
        /// Property for whether to put green chile sauce on the current instance of the side menu Glowing Haystack
        /// </summary>
        public bool GreenChileSauce
        {
            get { return _greenChileSauce; }
            set
            {
                _greenChileSauce = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Private backing field for the Tomatoes property
        /// </summary>
        private bool _tomatoes = true;

        /// <summary>
        /// Property for whether to put tomatoes on the current instance of the side menu Glowing Haystack
        /// </summary>
        public bool Tomatoes
        {
            get { return _tomatoes; }
            set
            {
                _tomatoes = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Property for the price of the current instance of the side menu Glowing Haystack
        /// </summary>
        public override decimal Price { get; } = 2.00m;

        /// <summary>
        /// Property for the calories of the current instance of the side menu Glowing Haystack
        /// </summary>
        public override uint Calories 
        {
            get
            {
                uint calories = 470;
                if (GreenChileSauce) calories += 15;
                if (SourCream) calories += 23;
                if (Tomatoes) calories += 22;
                return calories;
            }
        }

        /// <summary>
        /// Property for the special instructions for the current instance of the side menu Glowing Haystack
        /// </summary>
        public override IEnumerable<string> SpecialInstructions 
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!SourCream) instructions.Add("Hold Sour Cream");
                if (!GreenChileSauce) instructions.Add("Hold Green Chili Sauce");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                return instructions;
            } 
        }
    }
}
