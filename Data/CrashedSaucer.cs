/* CrashedSaucer.cs
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
    /// Class for the menu Crashed Saucer
    /// </summary>
    public class CrashedSaucer : Entree, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the name of the menu Crashed Saucer
        /// </summary>
        public override string Name { get; } = "Crashed Saucer";

        /// <summary>
        /// Property for the description of the menu Crashed Saucer
        /// </summary>
        public override string Description { get; } = "A stack of crispy french toast smothered in syrup and topped with a pat of butter.";

        /// <summary>
        /// Private backing field for the toast count
        /// </summary>
        private uint _stackSize = 2;

        /// <summary>
        /// Property for the toast count for the current instance of the menu Crashed Saucer
        /// </summary>
        public uint StackSize
        {
            get => _stackSize;
            set
            {
                if (value > 6) _stackSize = 6;
                else _stackSize = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Price"));
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Private backing field for the Syrup property
        /// </summary>
        private bool _syrup = true;

        /// <summary>
        /// Property for whether to put syrup on the current instance of the menu Crashed Saucer
        /// </summary>
        public bool Syrup
        {
            get { return _syrup; }
            set
            {
                _syrup = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Private backing field for the Butter property
        /// </summary>
        private bool _butter = true;

        /// <summary>
        /// Property for whether to put butter on the current instance of the menu Crashed Saucer
        /// </summary>
        public bool Butter
        {
            get { return _butter; }
            set
            {
                _butter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Property for the price of the current instance of the menu Crashed Saucer
        /// </summary>
        public override decimal Price
        {
            get
            {
                if (_stackSize <= 2) return 6.45m;
                else return (6.45m + (1.50m * (StackSize - 2)));
            }
        }

        /// <summary>
        /// Property for the calories of the current instance of the menu Crashed Saucer
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 149 * StackSize;
                if (Syrup) calories += 52;
                if (Butter) calories += 35;
                return calories;
            }
        }

        /// <summary>
        /// Property for the special instructions for the current instance of the menu Crashed Saucer
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (StackSize != 2) instructions.Add($"{StackSize} slice(s)");
                if (!Butter) instructions.Add("Hold Butter");
                if (!Syrup) instructions.Add("Hold Syrup");
                return instructions;
            }
        }
        
    }
}
