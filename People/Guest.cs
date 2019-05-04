using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Accounts;
using Animals;
using BoothItems;
using CagedItems;
using Foods;
using MoneyCollectors;
using Reproducers;
using Utilities;
using VendingMachines;

namespace People
{
    /// <summary>
    /// The class which is used to represent a guest.
    /// </summary>
    public class Guest : IEater, ICageable
    {
        /// <summary>
        /// Defines a random number.
        /// </summary>
        private static Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// The age of the guest.
        /// </summary>
        private int age;

        /// <summary>
        /// The name of the guest.
        /// </summary>
        private string name;

        /// <summary>
        /// The guest's wallet.
        /// </summary>
        private Wallet wallet;

        /// <summary>
        /// A list of items in the bag.
        /// </summary>
        private List<Item> bag;

        /// <summary>
        /// Gets the gender of a guest.
        /// </summary>
        private Gender gender;

        /// <summary>
        /// The guest's checking account.
        /// </summary>
        private IMoneyCollector checkingAccount;
        
        /// <summary>
        /// Initializes a new instance of the Guest class.
        /// </summary>
        /// <param name="name">The name of the guest.</param>
        /// <param name="age">The age of the guest.</param>
        /// <param name="moneyBalance">The initial amount of money to put into the guest's wallet.</param>
        /// <param name="walletColor">The color of the guest's wallet.</param>
        /// <param name="gender">The gender of the guest.</param>
        /// <param name="checkingAccount">The guest's checking account.</param>
        public Guest(string name, int age, decimal moneyBalance, WalletColor walletColor, Gender gender, IMoneyCollector checkingAccount)
        {
            this.age = age;
            this.checkingAccount = checkingAccount;
            this.name = name;
            this.wallet = new Wallet(walletColor);
            this.wallet.AddMoney(moneyBalance);
            this.bag = new List<Item>();
            this.gender = gender;
            this.XPosition = random.Next(0, 201);
            this.YPosition = 400;
            this.ResourceKey = "Guest";
        }

        /// <summary>
        /// Gets or sets the value for the adopted animal.
        /// </summary>
        public Animal AdoptedAnimal { get; set; }

        /// <summary>
        /// Gets or sets the age of the guest.
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age", "Please enter an age between 0 and 120.");
                }
                else if (value > 120)
                {
                    throw new ArgumentOutOfRangeException("Age", "Please enter an age between 0 and 120.");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        /// <summary>
        /// Gets the guests checking account.
        /// </summary>
        public IMoneyCollector CheckingAccount
        {
            get
            {
                return this.checkingAccount;
            }
        }

        /// <summary>
        /// Gets the display size.
        /// </summary>
        public double DisplaySize
        {
            get
            {
                return 0.6;
            }
        }
        
        /// <summary>
        /// Gets or sets the gender of the guest.
        /// </summary>
        public Gender Gender
        {
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }

        /// <summary>
        /// Gets or sets the name of the guest.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (!Regex.IsMatch(value, @"^[a-zA-Z ]+$"))
                {
                    throw new FormatException("The name must only include letters and spaces.");
                }
                else
                {
                    this.name = value;
                }
            }
        }

        /// <summary>
        /// Gets the resource key.
        /// </summary>
        public string ResourceKey { get; }

        /// <summary>
        /// Gets the guest's wallet.
        /// </summary>
        public Wallet Wallet
        {
            get
            {
                return this.wallet;
            }
        }

        /// <summary>
        /// Gets or sets the weight of the guest.
        /// </summary>
        public double Weight
        {
            get
            {
                // Confidential.
                return 0.0;
            }

            set
            {
                this.Weight = value;
            }
        }

        /// <summary>
        /// Gets the weight gain percentage.
        /// </summary>
        public double WeightGainPercentage
        {
            get
            {
                return 0.0;
            }
        }

        /// <summary>
        /// Gets the x position.
        /// </summary>
        public int XPosition { get; private set; }

        /// <summary>
        /// Gets the y position.
        /// </summary>
        public int YPosition { get; private set; }

        /// <summary>
        /// Gets the x direction.
        /// </summary>
        public HorizontalDirection XDirection { get; private set; }

        /// <summary>
        /// Gets the y direction.
        /// </summary>
        public VerticalDirection YDirection { get; private set; }

        /// <summary>
        /// Withdraws money from the guest's checking account.
        /// </summary>
        /// <param name="amount"> The amount to withdraw.</param>
        public void WithdrawMoney(decimal amount)
        {
            decimal result = this.CheckingAccount.RemoveMoney(amount);
            this.Wallet.AddMoney(result);
        }

        /// <summary>
        /// Eats the specified food.
        /// </summary>
        /// <param name="food">The food to eat.</param>
        public void Eat(Food food)
        {
            // Eat the food.
        }

        /// <summary>
        /// Feeds the specified eater.
        /// </summary>
        /// <param name="eater">The eater to be fed.</param>
        /// <param name="animalSnackMachine">The animal snack machine from which to buy food.</param>
        public void FeedAnimal(IEater eater, VendingMachine animalSnackMachine)
        {
            // Find food price.
            decimal price = animalSnackMachine.DetermineFoodPrice(eater.Weight);

            if (this.wallet.MoneyBalance < price)
            {
                // Get money from wallet.
                this.WithdrawMoney(price * 5);
            }

            decimal payment = this.wallet.RemoveMoney(price);

            // Buy food.
            Food food = animalSnackMachine.BuyFood(payment);

            // Feed animal.
            eater.Eat(food);
        }

        /// <summary>
        /// Allows the guest to visit the information booth.
        /// </summary>
        /// <param name="informationBooth"> The name of the booth.</param>
        public void VisitInformationBooth(GivingBooth informationBooth)
        {
            Map freeMap = informationBooth.GiveFreeMap();
            this.bag.Add(freeMap);

            CouponBook freeBook = informationBooth.GiveFreeCouponBook();
            this.bag.Add(freeBook);
        }

        /// <summary>
        /// Visit the ticket booth.
        /// </summary>
        /// <param name="ticketBooth"> Passes in the ticket booth. </param>
        /// <returns> Returns the ticket.</returns>
        public Ticket VisitTicketBooth(MoneyCollectingBooth ticketBooth)
        {
            if (this.wallet.MoneyBalance < (ticketBooth.TicketPrice + ticketBooth.WaterBottlePrice))
            {
                this.WithdrawMoney(ticketBooth.TicketPrice * 2);
            }

            // Define variable to hold ticket.            
            decimal ticketPrice = ticketBooth.TicketPrice;
            decimal ticketPayment = this.wallet.RemoveMoney(ticketPrice);
            Ticket ticket = ticketBooth.SellTicket(ticketPayment);
            decimal waterBottlePrice = ticketBooth.WaterBottlePrice;
            decimal payment = this.wallet.RemoveMoney(waterBottlePrice);
            WaterBottle bottle = ticketBooth.SellWaterBottle(payment);
            this.bag.Add(bottle);

            return ticket;
        }

        /// <summary>
        /// Over rides the To String.
        /// </summary>
        /// <returns> Returns the value.</returns>
        public override string ToString()
        {
            if (this.AdoptedAnimal != null)
            {
                return string.Format("{0} : {1} [${2}/${3}], {4}", this.Name, this.Age, this.Wallet.MoneyBalance, this.CheckingAccount.MoneyBalance, this.AdoptedAnimal.Name);
            }
            else
            {
                return string.Format("{0} : {1} [${2}/${3}]", this.Name, this.Age, this.Wallet.MoneyBalance, this.CheckingAccount.MoneyBalance);
            }
        }
    }
}