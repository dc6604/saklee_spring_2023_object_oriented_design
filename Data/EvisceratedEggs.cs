/* EvisceratedEggs.cs
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
    /// Class for the side menu Eviscerated Eggs
    /// </summary>
    public class EvisceratedEggs : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the name of the side menu Eviscerated Eggs
        /// </summary>
        public override string Name { get; } = "Eviscerated Eggs";

        /// <summary>
        /// Property for the description of the side menu Eviscerated Eggs
        /// </summary>
        public override string Description { get; } = "Eggs prepared the way you like.";

        /// <summary>
        /// Private backing field for how the egg is to be cooked
        /// </summary>
        private EggStyle _style = EggStyle.OverEasy;

        /// <summary>
        /// Property for how the egg is to be cooked for the current instance of the side menu Eviscerated Eggs
        /// </summary>
        public EggStyle Style
        {
            get
            {
                return _style;
            }
            set
            {
                _style = value;
            }
        }

        /// <summary>
        /// Private backing field for the number of the eggs
        /// </summary>
        private uint _count = 2;

        /// <summary>
        /// Property for the number of the eggs for the current instance of the side menu Eviscerated Eggs
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
        /// Property for the price of the current instance of the side menu Eviscerated Eggs
        /// </summary>
        public override decimal Price { get => 1.00m * Count; }

        /// <summary>
        /// Property for the calories of the current instance of the side menu Eviscerated Eggs
        /// </summary>
        public override uint Calories
        {
            get
            {
                uint calories = 78 * Count;
                return calories;
            }
        }

        /// <summary>
        /// Property for the special instructions for the current instance of the side menu Eviscerated Eggs
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (Style == EggStyle.OverEasy) instructions.Add("Over Easy");
                if (Style == EggStyle.SunnySideUp) instructions.Add("Sunny Side Up");
                if (Style == EggStyle.SoftBoiled) instructions.Add("Soft Boiled");
                if (Style == EggStyle.HardBoiled) instructions.Add("Hard Boiled");
                if (Style == EggStyle.Poached) instructions.Add("Poached");
                if (Style == EggStyle.Scrambled) instructions.Add("Scrambled");
                if (Count != 2) instructions.Add($"{Count} egg(s)");
                return instructions;
            }
        }
    }
}
