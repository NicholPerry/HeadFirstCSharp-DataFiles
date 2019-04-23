using System;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows;
using CagedItems;
using Foods;
using Reproducers;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent an animal.
    /// </summary>
    public abstract class Animal : IEater, IMover, IReproducer, ICageable
    {
        /// <summary>
        /// Defines a random number.
        /// </summary>
        private static Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// The age of the animal.
        /// </summary>
        private int age;

        /// <summary>
        /// The weight of a newborn baby (as a percentage of the parent's weight).
        /// </summary>
        private double babyWeightPercentage;

        /// <summary>
        /// A value indicating whether or not the animal is pregnant.
        /// </summary>
        private bool isPregnant;

        /// <summary>
        /// The name of the animal.
        /// </summary>
        private string name;

        /// <summary>
        /// The weight of the animal (in pounds).
        /// </summary>
        private double weight;

        /// <summary>
        /// Gets the gender of an animal.
        /// </summary>
        private Gender gender;

        /// <summary>
        /// The move timer.
        /// </summary>
        private Timer moveTimer;

        /// <summary>
        /// Initializes a new instance of the Animal class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        /// <param name="gender"> The gender of the animal.</param>
        public Animal(string name, int age, double weight, Gender gender)
        {
            this.age = age;
            this.name = name;
            this.weight = weight;
            this.gender = gender;
            this.XPositionMax = 800;
            this.XPosition = random.Next(1, this.XPositionMax + 1);
            this.XDirection = random.Next(0, 2) == 0 ? HorizontalDirection.Left : HorizontalDirection.Right;
            this.YPositionMax = 400;
            this.YPosition = random.Next(1, this.YPositionMax + 1);
            this.YDirection = random.Next(0, 2) == 0 ? VerticalDirection.Up : VerticalDirection.Down;
            this.MoveDistance = random.Next(5, 16);
            this.moveTimer = new Timer(1000);
            this.moveTimer.Elapsed += this.MoveHandler;
            this.moveTimer.Start();
        }

        /// <summary>
        /// Gets or sets the age of the animal.
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
                    throw new ArgumentOutOfRangeException("Age", "Please enter an age between 0 and 100.");
                }
                else if (value > 100)
                {
                    throw new ArgumentOutOfRangeException("Age", "Please enter an age between 0 and 100.");
                }
                else
                {
                    this.age = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the gender of the animal.
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
        /// Gets a value indicating whether or not the animal is pregnant.
        /// </summary>
        public bool IsPregnant
        {
            get
            {
                return this.isPregnant;
            }
        }

        /// <summary>
        /// Gets or sets how many pixels in the window the animal will move.
        /// </summary>
        public int MoveDistance { get; set; }

        /// <summary>
        /// Gets or sets the name of the animal.
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
        /// Gets or sets the animal's weight (in pounds).
        /// </summary>
        public double Weight
        {
            get
            {
                return this.weight;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Weight", "Please enter a weight between 0 and 1000.");
                }
                else if (value > 1000)
                {
                    throw new ArgumentOutOfRangeException("Weight", "Please enter a weight between 0 and 1000.");
                }
                else
                {
                    this.weight = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the way in which the animal will be facing (left or right).
        /// </summary>
        public HorizontalDirection XDirection { get; set; }

        /// <summary>
        /// Gets or sets the pixel coordinates (where in the cage) that the animal will be drawn at.
        /// </summary>
        public int XPosition { get; set; }

        /// <summary>
        /// Gets or sets the bounds of the window so that the animal stays within the window (cage).
        /// </summary>
        public int XPositionMax { get; set; }

        /// <summary>
        /// Gets or sets the way in which the animal will be facing (up or down).
        /// </summary>
        public VerticalDirection YDirection { get; set; }

        /// <summary>
        /// Gets or sets the pixel coordinates (where in the cage) that the animal will be drawn at.
        /// </summary>
        public int YPosition { get; set; }

        /// <summary>
        /// Gets or sets the bounds of the window so that the animal stays within the window (cage).
        /// </summary>
        public int YPositionMax { get; set; }

        /// <summary>
        /// Gets the display size.
        /// </summary>
        public virtual double DisplaySize
        {
            get
            {
                return this.age == 0 ? 0.5 : 1.0;
            }
        }

        /// <summary>
        /// Gets the resource key.
        /// </summary>
        public string ResourceKey
        {
            get
            {
                return this.Age == 0 ? $"{this.GetType().Name}Baby" : $"{this.GetType().Name}Adult";
            }
        }

        /// <summary>
        /// Gets or sets the weight of a newborn baby (as a percentage of the parent's weight).
        /// </summary>
        protected double BabyWeightPercentage
        {
            get
            {
                return this.babyWeightPercentage;
            }

            set
            {
                this.babyWeightPercentage = value;
            }
        }

        /// <summary>
        /// Gets the percentage of weight gained for each pound of food eaten.
        /// </summary>
        protected abstract double WeightGainPercentage
        {
            get;
        }

        /// <summary>
        /// Converts the animal type to a type.
        /// </summary>
        /// <param name="animalType"> The type of animal finding.</param>
        /// <returns> Returns the type of animal.</returns>
        public static Type ConvertAnimalTypeToType(AnimalType animalType)
        {
            switch (animalType)
            {
                case AnimalType.Chimpanzee:
                    return typeof(Chimpanzee);
                case AnimalType.Dingo:
                    return typeof(Dingo);
                case AnimalType.Eagle:
                    return typeof(Eagle);
                case AnimalType.Hummingbird:
                    return typeof(Hummingbird);
                case AnimalType.Kangaroo:
                    return typeof(Kangaroo);
                case AnimalType.Ostrich:
                    return typeof(Ostrich);
                case AnimalType.Platypus:
                    return typeof(Platypus);
                case AnimalType.Shark:
                    return typeof(Shark);
                case AnimalType.Squirrel:
                    return typeof(Squirrel);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Eats the specified food.
        /// </summary>
        /// <param name="food">The food to eat.</param>
        public virtual void Eat(Food food)
        {
            // Increase animal's weight as a result of eating food.
            this.Weight += food.Weight * (this.WeightGainPercentage / 100);
        }

        /// <summary>
        /// Makes the animal pregnant.
        /// </summary>
        public void MakePregnant()
        {
            this.isPregnant = true;
        }

        /// <summary>
        /// Moves about.
        /// </summary>
        public abstract void Move();

        /// <summary>
        /// Creates another reproducer of its own type.
        /// </summary>
        /// <returns>The resulting baby reproducer.</returns>
        public virtual IReproducer Reproduce()
        {
            // Create a baby reproducer.
            Animal baby = Activator.CreateInstance(this.GetType(), string.Empty, 0, this.Weight * (this.BabyWeightPercentage / 100)) as Animal;

            // Reduce mother's weight by 25 percent more than the value of the baby's weight.
            this.Weight -= baby.Weight * 1.25;

            // Make mother not pregnant after giving birth.
            this.isPregnant = false;

            return baby;
        }

        /// <summary>
        /// Generates a string representation of the animal.
        /// </summary>
        /// <returns>A string representation of the animal.</returns>
        public override string ToString()
        {
            return this.name + ": " + this.GetType().Name + " (" + this.age + ", " + this.Weight + ")" + (this.isPregnant == true ? " P" : string.Empty);
        }

        /// <summary>
        /// Handles the animal moving.
        /// </summary>
        /// <param name="sender"> The object that initiated the event.</param>
        /// <param name="e"> The event arguments for the event.</param>
        private void MoveHandler(object sender, ElapsedEventArgs e)
        {
#if DEBUG
            this.moveTimer.Stop();
#endif
            this.Move();
#if DEBUG
            this.moveTimer.Start();
#endif
        }
    }
}