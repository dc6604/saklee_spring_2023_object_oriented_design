/* LivestockMutilation.cs
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
    /// Class for the menu Livestock Mutilation
    /// </summary>
    public class LivestockMutilation : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the name of the menu Livestock Mutilation
        /// </summary>
        public override string Name { get; } = "Livestock Mutilation";

        /// <summary>
        /// Property for the description of the menu Livestock Mutilation
        /// </summary>
        public override string Description { get; } = "A hearty serving of biscuits, smothered in sausage-laden gravy.";

        /// <summary>
        /// Private backing field for the number of biscuits
        /// </summary>
        private uint _biscuits = 3;

        /// <summary>
        /// Property for the number of biscuits for the current instance of the menu Livestock Mutilation
        /// </summary>
        public uint Biscuits
        {
            get
            {
                return _biscuits;
            }
            set
            {
                if (value > 8) _biscuits = 8;
                else _biscuits = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Private backing field for the Gravy property
        /// </summary>
        private bool _gravy = true;

        /// <summary>
        /// Property for whether to put gravy on the current instance of the menu Livestock Mutilation
        /// </summary>
        public bool Gravy
        {
            get { return _gravy; }
            set
            {
                _gravy = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Property for the price of the current instance of the menu Livestock Mutilation
        /// </summary>
        public override decimal Price 
        { 
            get
            {
                if (_biscuits <= 3) return 7.25m;
                else return (7.25m + (1.00m * (_biscuits - 3)));
            } 
        }

        /// <summary>
        /// Property for the calories of the current instance of the menu Livestock Mutilation
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 49 * Biscuits;
                if (Gravy) calories += 140;
                return calories;
            }
        }

        /// <summary>
        /// Property for the special instructions for the current instance of the menu Livestock Mutilation
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Biscuits != 3) instructions.Add($"{Biscuits} biscuit(s)");
                if (!Gravy) instructions.Add("Hold Gravy");
                return instructions;
            }
        }
    }
}
