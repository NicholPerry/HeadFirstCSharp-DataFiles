using Animals;
using Foods;
using Reproducers;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent a platypus.
    /// </summary>
    public sealed class Platypus : Mammal, IHatchable
    {
        /// <summary>
        /// Initializes a new instance of the Platypus class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        /// <param name="gender">The gender of the animal.</param>
        public Platypus(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            this.BabyWeightPercentage = 12.0;
            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Swim);
            this.EatBehavior = new ShowAffectionBehavior();
            this.ReproduceBehavior = new LayEggBehavior();
        }

        /// <summary>
        /// Gets the display size.
        /// </summary>
        public override double DisplaySize
        {
            get
            {
                return this.Age == 0 ? 0.8 : 1.1;
            }
        }

        /// <summary>
        /// Hatches the animal.
        /// </summary>
        public void Hatch()
        {
            // The animal hatches from an egg.
        }
    }
}