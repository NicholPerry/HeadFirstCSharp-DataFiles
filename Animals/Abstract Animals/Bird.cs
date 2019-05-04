using Animals;
using Reproducers;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent a bird.
    /// </summary>
    public abstract class Bird : Animal, IHatchable
    {
        /// <summary>
        /// Initializes a new instance of the Bird class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        /// <param name="gender">The gender of the animal.</param>
        public Bird(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Fly);
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

        /// <summary>
        /// Hatches from its egg.
        /// </summary>
        public void Hatch()
        {
            // Break out of egg.
        }
    }
}