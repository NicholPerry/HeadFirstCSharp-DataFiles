using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoothItems
{
    /// <summary>
    /// The class which is used to represent a map.
    /// </summary>
    public class Map : Item
    {
        /// <summary>
        /// The date the map is issued.
        /// </summary>
        private DateTime dateIssued;

        /// <summary>
        /// Initializes a new instance of the Map class.
        /// </summary>
        /// <param name="weight"> The weight of the map.</param>
        /// <param name="dateIssued"> The date the map was issued.</param>
        public Map(double weight, DateTime dateIssued)
            : base(weight)
        {
            this.dateIssued = dateIssued;
        }

        /// <summary>
        /// Gets the value for the date the map was issued.
        /// </summary>
        public DateTime DateIssued
        {
            get
            {
                return this.dateIssued;
            }
        }
    }
}
