using System.Collections.Generic;
using Animals;

namespace Zoos
{
    /// <summary>
    /// The class which is used to represent a SortResult.
    /// </summary>
    public class SortResult
    {
        /// <summary>
        /// Gets or sets the animal list.
        /// </summary>
        public List<Animal> Animals { get; set; }

        /// <summary>
        /// Gets or sets the compare counter.
        /// </summary>
        public int CompareCount { get; set; }

        /// <summary>
        /// Gets or sets the elapsed milliseconds.
        /// </summary>
        public double ElapsedMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets the swap counter.
        /// </summary>
        public int SwapCount { get; set; }
    }
}
