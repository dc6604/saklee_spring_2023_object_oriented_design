/* InorganicSubstance.cs
 * Author: Sak Lee
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFlyingSaucer.Data
{
    /// <summary>
    /// Class for the drink Inorganic Substance
    /// </summary>
    public class InorganicSubstance : Drink
    {
        /// <summary>
        /// Property for the name of the drink Inorganic Substance
        /// </summary>
        public override string Name { get; } = "Inorganic Substance";

        /// <summary>
        /// Property for the description of the drink Inorganic Substance
        /// </summary>
        public override string Description { get; } = "A cold glass of ice water.";

        /// <summary>
        /// Serving size for the current instance of the drink Inorganic Substance
        /// </summary>
        public override ServingSize Size { get; set; } = ServingSize.Small;

        /// <summary>
        /// Property for whether to put ice in the current instance of the drink Inorganic Substance
        /// </summary>
        public bool Ice { get; set; } = true;

        /// <summary>
        /// Property for the price of the current instance of the drink Inorganic Substance
        /// </summary>
        public override decimal Price { get; } = 0.00m;

        /// <summary>
        /// Property for the calories of the current instance of the drink Inorganic Substance
        /// </summary>
        public override uint Calories { get; } = 0;

        /// <summary>
        /// Property for the special instructions for the current instance of the drink Inorganic Substance
        /// </summary>
        public override IEnumerable<string> SpecialInstructions
        {
            get
            {
                List<string> instructions = new List<string>();
                if (!Ice) instructions.Add("No Ice");
                return instructions;
            }
        }
    }
}
