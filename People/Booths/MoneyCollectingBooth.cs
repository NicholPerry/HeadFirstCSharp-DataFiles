using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Animals;
using BoothItems;
using MoneyCollectors;
using Reproducers;

namespace People
{
    /// <summary>
    /// The class which is used to represent a money collecting booth.
    /// </summary>
    public class MoneyCollectingBooth : Booth
    {
        /// <summary>
        /// The price of a ticket.
        /// </summary>
        private decimal ticketPrice;

        /// <summary>
        /// The price of a water bottle.
        /// </summary>
        private decimal waterBottlePrice;

        /// <summary>
        /// The booth's money box.
        /// </summary>
        private IMoneyCollector moneyBox;

        /// <summary>
        /// Initializes a new instance of the MoneyCollectingBooth class.
        /// </summary>
        /// <param name="attendant"> The attendant of the booth.</param>
        /// <param name="ticketPrice"> The price of a ticket.</param>
        /// <param name="waterBottlePrice"> The price of a water bottle.</param>
        /// <param name="moneyBox">The money box container of the money collecting booth.</param>
        public MoneyCollectingBooth(Employee attendant, decimal ticketPrice, decimal waterBottlePrice, IMoneyCollector moneyBox)
            : base(attendant)
        {
            this.ticketPrice = ticketPrice;
            this.waterBottlePrice = waterBottlePrice;
            this.moneyBox = moneyBox;

            // Create 5 tickets.
            for (int i = 0; i < 5; i++)
            {
                this.Items.Add(new Ticket(this.ticketPrice, i, 0.01));
            }

            // Create 5 water bottles.
            for (int i = 0; i < 5; i++)
            {
                this.Items.Add(new WaterBottle(this.waterBottlePrice, i, 1.0));
            }
        }

        /// <summary>
        /// Gets the money balance.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBox.MoneyBalance;
            }
        }

        /// <summary>
        /// Gets the ticket price.
        /// </summary>
        public decimal TicketPrice
        {
            get
            {
                return this.ticketPrice;
            }
        }

        /// <summary>
        /// Gets the water bottle price.
        /// </summary>
        public decimal WaterBottlePrice
        {
            get
            {
                return this.waterBottlePrice;
            }
        }

        /// <summary>
        /// Adds money to the booth.
        /// </summary>
        /// <param name="amount"> The amount to add.</param>
        public void AddMoney(decimal amount)
        {
            this.moneyBox.AddMoney(amount);
        }

        /// <summary>
        /// Removes money from the booth.
        /// </summary>
        /// <param name="amount"> The amount to remove.</param>
        /// <returns> Returns the result.</returns>
        public decimal RemoveMoney(decimal amount)
        {
            decimal result = this.moneyBox.RemoveMoney(amount);
            return result;
        }

        /// <summary>
        /// Sell a ticket.
        /// </summary>
        /// <param name="payment"> The payment for a ticket.</param>
        /// <returns> Return the ticket.</returns>
        public Ticket SellTicket(decimal payment)
        {
            Ticket ticket = null;

            try
            {
                if (payment >= this.TicketPrice)
                {
                    // Define variable to hold ticket.
                    ticket = this.Attendant.FindItem(this.Items, typeof(Ticket)) as Ticket;

                    if (ticket != null)
                    {
                        this.AddMoney(payment);
                    }
                }
            }
            catch (MissingItemException ex)
            {
                throw new NullReferenceException("Ticket not found.", ex);
            }

            return ticket;
        }

        /// <summary>
        /// Sell a water bottle.
        /// </summary>
        /// <param name="payment"> The payment for a water bottle.</param>
        /// <returns> Returns the water bottle.</returns>
        public WaterBottle SellWaterBottle(decimal payment)
        {
            // Define variable to hold water bottle.
            WaterBottle waterBottle = null;

            try
            {
                if (payment >= this.WaterBottlePrice)
                {
                    // Define variable to hold ticket.
                    waterBottle = this.Attendant.FindItem(this.Items, typeof(WaterBottle)) as WaterBottle;

                    if (waterBottle != null)
                    {
                        this.AddMoney(payment);
                    }
                }
            }
            catch (MissingItemException ex)
            {
                throw new NullReferenceException("Water bottle not found.", ex);
            }      

            return waterBottle;
        }
    }
}
