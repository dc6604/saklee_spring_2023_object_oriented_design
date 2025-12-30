/* CropCircle.cs
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
    /// Class for the side menu Crop Circle
    /// </summary>
    public class CropCircle : Side, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Property for the name of the side menu Crop Circle
        /// </summary>
        public override string Name { get; } = "Crop Circle";

        /// <summary>
        /// Property for the description of the side menu Crop Circle
        /// </summary>
        public override string Description { get; } = "Oatmeal topped with mixed berries.";

        /// <summary>
        /// Private backing field for the Berries property
        /// </summary>
        private bool _berries = true;

        /// <summary>
        /// Property for whether to put berries on the current instance of the side menu Crop Circle
        /// </summary>
        public bool Berries
        {
            get { return _berries; }
            set
            {
                _berries = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Calories"));
            }
        }

        /// <summary>
        /// Property for the price of the current instance of the side menu Crop Circle
        /// </summary>
        public override decimal Price { get; } = 2.00m;

        /// <summary>
        /// Property for the calories of the current instance of the side menu Crop Circle
        /// </summary>
        public override uint Calories 
        { 
            get
            {
                uint calories = 158;
                if (Berries) calories += 89;
                return calories;
            } 
        }

        /// <summary>
        /// Property for the special instructions for the current instance of the side menu Crop Circle
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Berries) instructions.Add("Hold Berries");
                return instructions;
            }
        }
    }
}
