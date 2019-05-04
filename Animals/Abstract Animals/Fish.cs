using Animals;
using Reproducers;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent a fish.
    /// </summary>
    public abstract class Fish : Animal
    {
        /// <summary>
        /// Initializes a new instance of the Fish class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        /// <param name="gender">The gender of the animal.</param>
        public Fish(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Swim);
            this.EatBehavior = new ConsumeBehavior();
            this.ReproduceBehavior = new LayEggBehavior();
        }

        /// <summary>
        /// Gets the percentage of weight gained for each pound of food eaten.
        /// </summary>
        public override double WeightGainPercentage
        {
            get
            {
                return 5.0;
            }
        }
    }
}