using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCollectors
{
    /// <summary>
    /// The class which is used to represent a money box.
    /// </summary>
    public class MoneyBox : MoneyCollector
    {
        /// <summary>
        /// Removes money from the money box.
        /// </summary>
        /// <param name="amount"> The amount to remove.</param>
        /// <returns> Returns the amount removed.</returns>
        public override decimal RemoveMoney(decimal amount)
        {
            decimal result = 0.00m;
            this.Unlock();
            result = base.RemoveMoney(amount);
            this.Lock();

            return result;
        }

        /// <summary>
        /// Locks the money box.
        /// </summary>
        private void Lock()
        {
        }

        /// <summary>
        /// Unlocks the money box.
        /// </summary>
        private void Unlock()
        {
        }
    }
}
