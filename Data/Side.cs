/* Side.cs
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
    /// Base class for side menu item
    /// </summary>
    public abstract class Side : IMenuItem, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Name of the side
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Description of the side
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Price of the side
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// Calories of the side
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Special instructions for the side
        /// </summary>
        public abstract IEnumerable<string> SpecialInstructions { get; }

        /// <summary>
        /// Method to override GUI list display
        /// </summary>
        /// <returns>What to display</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
