/* IMenuItem.cs
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
    /// Interface for menu items
    /// </summary>
    public interface IMenuItem: INotifyPropertyChanged
    {

        /// <summary>
        /// Name of the menu
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Description of the menu
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Price of the menu
        /// </summary>
        decimal Price { get; }

        /// <summary>
        /// Calories of the menu
        /// </summary>
        uint Calories { get; }

        /// <summary>
        /// Special instructions for the menu
        /// </summary>
        IEnumerable<string> SpecialInstructions { get; }
    }
}
