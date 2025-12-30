/* Entree.cs
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
    /// Base class for entree menu item
    /// </summary>
    public abstract class Entree : IMenuItem, INotifyPropertyChanged
    {
        /// <summary>
        /// Property change event declared
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Name of the entree
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Description of the entree
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Price of the entree
        /// </summary>
        public abstract decimal Price { get; }

        /// <summary>
        /// Calories of the entree
        /// </summary>
        public abstract uint Calories { get; }

        /// <summary>
        /// Special instructions for the entree
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
