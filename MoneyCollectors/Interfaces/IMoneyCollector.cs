using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCollectors
{
    /// <summary>
    /// The interface for an IMoneyCollector.
    /// </summary>
    public interface IMoneyCollector
    {
        /// <summary>
        /// Gets the money balance.
        /// </summary>
        decimal MoneyBalance { get; }

        /// <summary>
        /// Adds money.
        /// </summary>
        /// <param name="amount"> The amount to add. </param>
        void AddMoney(decimal amount);

        /// <summary>
        /// Removes money.
        /// </summary>
        /// <param name="amount"> The amount to remove. </param>
        /// <returns> Returns the amount removed. </returns>
        decimal RemoveMoney(decimal amount);
    }
}
