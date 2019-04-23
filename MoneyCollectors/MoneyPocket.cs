using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCollectors
{
    /// <summary>
    /// The class which is used to represent a money pocket.
    /// </summary>
    public class MoneyPocket : MoneyCollector
    {
        /// <summary>
        /// Removes money from the money pocket.
        /// </summary>
        /// <param name="amount"> The amount to remove.</param>
        /// <returns> Returns the amount removed.</returns>
        public override decimal RemoveMoney(decimal amount)
        {
            decimal result = 0.00m;
            this.Unfold();
            result = base.RemoveMoney(amount);
            this.Fold();

            return result;
        }

        /// <summary>
        /// Folds the money pocket.
        /// </summary>
        private void Fold()
        {
        }

        /// <summary>
        /// Unfolds the money pocket.
        /// </summary>
        private void Unfold()
        {
        }
    }
}
