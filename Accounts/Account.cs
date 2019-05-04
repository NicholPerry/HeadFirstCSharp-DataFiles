using MoneyCollectors;

namespace Accounts
{
    /// <summary>
    /// The class which is used to represent an account.
    /// </summary>
    public class Account : IMoneyCollector
    {
        /// <summary>
        /// The accounts money balance.
        /// </summary>
        private decimal moneyBalance;

        /// <summary>
        /// Gets or sets the accounts money balance.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBalance;
            }

            set
            {
                this.moneyBalance = value;
            }
        }

        /// <summary>
        /// Adds money to the account.
        /// </summary>
        /// <param name="amount"> The amount to add.</param>
        public void AddMoney(decimal amount)
        {
            this.moneyBalance += amount;
        }

        /// <summary>
        /// Removes money from the account.
        /// </summary>
        /// <param name="amount"> The amount to remove.</param>
        /// <returns> Returns the amount removed.</returns>
        public decimal RemoveMoney(decimal amount)
        {
            this.moneyBalance -= amount;
            return amount;
        }
    }
}
