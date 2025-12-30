/* OuterOmelette.cs
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
    /// Class for the menu Outer Omelette
    /// </summary>
    public class OuterOmelette : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the name of the menu Outer Omelette
        /// </summary>
        public override string Name { get; } = "Outer Omelette";

        /// <summary>
        /// Property for the description of the menu Outer Omelette
        /// </summary>
        public override string Description { get; } = "A fully loaded Omelette.";

        /// <summary>
        /// Private backing field for the CheddarCheese property
        /// </summary>
        private bool _cheddarCheese = true;

        /// <summary>
        /// Property for whether to put cheddar cheese on the current instance of the menu Outer Omelette
        /// </summary>
        public bool CheddarCheese
        {
            get { return _cheddarCheese; }
            set
            {
                _cheddarCheese = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Private backing field for the Peppers property
        /// </summary>
        private bool _peppers = true;

        /// <summary>
        /// Property for whether to put pepper on the current instance of the menu Outer Omelette
        /// </summary>
        public bool Peppers
        {
            get { return _peppers; }
            set
            {
                _peppers = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Private backing field for the Mushrooms property
        /// </summary>
        private bool _mushrooms = true;

        /// <summary>
        /// Property for whether to put mushrooms on the current instance of the menu Outer Omelette
        /// </summary>
        public bool Mushrooms
        {
            get { return _mushrooms; }
            set
            {
                _mushrooms = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Private backing field for the Tomatoes property
        /// </summary>
        private bool _tomatoes = true;

        /// <summary>
        /// Property for whether to put tomatoes on the current instance of the menu Outer Omelette
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
        /// Private backing field for the Onions property
        /// </summary>
        private bool _onions = true;

        /// <summary>
        /// Property for whether to put onions on the current instance of the menu Outer Omelette
        /// </summary>
        public bool Onions
        {
            get { return _onions; }
            set
            {
                _onions = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Property for the price of the current instance of the menu Outer Omelette
        /// </summary>
        public override decimal Price { get; } = 7.45m;

        /// <summary>
        /// Property for the calories of the current instance of the menu Outer Omelette
        /// </summary>
        public override uint Calories 
        {
            get
            {
                uint calories = 94;
                if (CheddarCheese) calories += 113;
                if (Peppers) calories += 24;
                if (Mushrooms) calories += 4;
                if (Tomatoes) calories += 22;
                if (Onions) calories += 22;
                return calories;
            }
        }

        /// <summary>
        /// Property for the special instructions for the current instance of the menu Outer Omelette
        /// </summary>
        public override IEnumerable<string> SpecialInstructions 
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!CheddarCheese) instructions.Add("Hold Cheddar Cheese");
                if (!Peppers) instructions.Add("Hold Peppers");
                if (!Mushrooms) instructions.Add("Hold Mushrooms");
                if (!Tomatoes) instructions.Add("Hold Tomatoes");
                if (!Onions) instructions.Add("Hold Onions");
                return instructions;
            } 
        }
    }
}
