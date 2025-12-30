/* YouAreToast.cs
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
    /// Class for the side menu You're Toast
    /// </summary>
    public class YouAreToast : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the name of the side menu You're Toast
        /// </summary>
        public override string Name { get; } = "You're Toast";

        /// <summary>
        /// Property for the description of the side menu You're Toast
        /// </summary>
        public override string Description { get; } = "Texas toast.";

        /// <summary>
        /// Private backing field for the slices of toast
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// Property for the slices of toast for the current instance of the side menu You're Toast
        /// </summary>
        public uint Count
        {
            get
            {
                return _count;
            }
            set
            {
                if (value > 12) _count = 12;
                else if (value < 1) _count = 1;
                else _count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Property for the price of the current instance of the side menu You're Toast
        /// </summary>
        public override decimal Price
        {
            get
            {
                return (1.00m * Count);
            }
        }

        /// <summary>
        /// Property for the calories of the current instance of the side menu You're Toast
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 100 * Count;
                return calories;
            }
        }

        /// <summary>
        /// Property for the special instructions for the current instance of the side menu You're Toast
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Count != 2) instructions.Add($"{Count} slice(s)");
                return instructions;
            }
        }
    }
}
