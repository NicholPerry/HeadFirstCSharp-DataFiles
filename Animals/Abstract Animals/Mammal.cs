using Foods;
using Reproducers;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent a mammal.
    /// </summary>
    public abstract class Mammal : Animal
    {
        /// <summary>
        /// Initializes a new instance of the Mammal class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        /// <param name="gender">The gender of the animal.</param>
        public Mammal(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
        }

        /// <summary>
        /// Gets the percentage of weight gained for each pound of food eaten.
        /// </summary>
        protected override double WeightGainPercentage
        {
            get
            {
                return 15.0;
            }
        }

        /// <summary>
        /// Moves by pacing.
        /// </summary>
        public override void Move()
        {
            // Pace.
            if (this.XDirection == HorizontalDirection.Right)
            {
                // If the animal position, and the distance they will move, is less than the max bounds of the window.
                if (this.XPosition + this.MoveDistance > this.XPositionMax)
                {
                    // The current position is now the right boundary of the window.
                    this.XPosition = this.XPositionMax;

                    // The animal will move left.
                    this.XDirection = HorizontalDirection.Left;
                }
                else
                {
                    // Move the animal to the right by its step distance.
                    this.XPosition += this.MoveDistance;
                }
            }
            else
            {
                // Takes the animals current position (right) and subtracts the number of steps to move, if boundary is less than 0...
                if (this.XPosition - this.MoveDistance < 0)
                {
                    // Boundary position gets set to zero.
                    this.XPosition = 0;

                    // The animal will move right.
                    this.XDirection = HorizontalDirection.Right;
                }
                else
                {
                    // Move the animal to the left by its step distance.
                    this.XPosition -= this.MoveDistance;
                }
            }
        }

        /// <summary>
        /// Creates another reproducer of its own type.
        /// </summary>
        /// <returns>The resulting baby reproducer.</returns>
        public override IReproducer Reproduce()
        {
            // Create a baby reproducer.
            IReproducer baby = base.Reproduce();

            // If the animal is not a platypus and baby is an eater...
            if (this.GetType() != typeof(Platypus) && baby is IEater)
            {
                // Feed the baby.
                this.FeedNewborn(baby as IEater);
            }

            return baby;
        }

        /// <summary>
        /// Feeds a baby eater.
        /// </summary>
        /// <param name="newborn">The eater to feed.</param>
        private void FeedNewborn(IEater newborn)
        {
            // Determine milk weight.
            double milkWeight = this.Weight * 0.005;

            // Generate milk.
            Food milk = new Food(milkWeight);

            // Feed baby.
            newborn.Eat(milk);

            // Reduce parent's weight.
            this.Weight -= milkWeight;
        }
    }
}