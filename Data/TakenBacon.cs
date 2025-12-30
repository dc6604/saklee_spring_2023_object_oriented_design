/* TakenBacon.cs
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
    /// Class for the side menu Taken Bacon
    /// </summary>
    public class TakenBacon : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the name of the side menu Taken Bacon
        /// </summary>
        public override string Name { get; } = "Taken Bacon";

        /// <summary>
        /// Property for the description of the side menu Taken Bacon
        /// </summary>
        public override string Description { get; } = "Crispy strips of bacon.";

        /// <summary>
        /// Private backing field for the number of strips of bacon
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// Property for the number of strips of bacon for the current instance of the side menu Taken Bacon
        /// </summary>
        public uint Count 
        { 
            get
            {
                return _count;
            } 
            set
            {
                if (value > 6) _count = 6;
                else if (value < 1) _count = 1;
                else _count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Property for the price of the current instance of the side menu Taken Bacon
        /// </summary>
        public override decimal Price 
        { 
            get
            {
                return (1.00m * Count);
            }
        }

        /// <summary>
        /// Property for the calories of the current instance of the side menu Taken Bacon
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 43 * Count;
                return calories;
            }
        }

        /// <summary>
        /// Property for the special instructions for the current instance of the side menu Taken Bacon
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Count != 2) instructions.Add($"{Count} strip(s)");
                return instructions;
            }
        }
    }
}
