using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoothItems
{
    /// <summary>
    /// The class which is used to represent an item.
    /// </summary>
    public abstract class Item
    {
        /// <summary>
        /// The weight of an item.
        /// </summary>
        private double weight;

        /// <summary>
        /// Initializes a new instance of the Item class.
        /// </summary>
        /// <param name="weight"> The weight of the item. </param>
        public Item(double weight)
        {
            this.weight = weight;
        }

        /// <summary>
        /// Gets the weight of an item.
        /// </summary>
        public double Weight
        {
            get
            {
                return this.weight;
            }
        }
    }
}
