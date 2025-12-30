/* MissingLinks.cs
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
    /// Class for the side menu Missing Links
    /// </summary>
    public class MissingLinks : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the name of the side menu Missing Links
        /// </summary>
        public override string Name { get; } = "Missing Links";

        /// <summary>
        /// Property for the description of the side menu Missing Links
        /// </summary>
        public override string Description { get; } = "Sizzling pork sausage links.";

        /// <summary>
        /// Private backing field for the number of the links of sausages
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// Property for the number of the links of sausages for the current instance of the side menu Missing Links
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value > 8) _count = 8;
                else if (value < 1) _count = 1;
                else _count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Property for the price of the current instance of the side menu Missing Links
        /// </summary>
        public override decimal Price 
        { 
            get
            {
                return (1.00m * Count);
            }
        }

        /// <summary>
        /// Property for the calories of the current instance of the side menu Missing Links
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 391 * Count;
                return calories;
            }
        }

        /// <summary>
        /// Property for the special instructions for the current instance of the side menu Missing Links
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Count != 2) instructions.Add($"{Count} link(s)");
                return instructions;
            }
        }

    }
}
