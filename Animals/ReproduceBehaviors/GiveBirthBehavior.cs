using Foods;
using Reproducers;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent a GiveBirthBehavior.
    /// </summary>
    public class GiveBirthBehavior : IReproduceBehavior
    {
        /// <summary>
        /// Creates another reproducer of its own type.
        /// </summary>
        /// <param name="mother"> The mother of the baby. </param>
        /// <param name="baby"> The resulting baby reproducer. </param>
        /// <returns> Returns the baby. </returns>
        public IReproducer Reproduce(Animal mother, Animal baby)
        {
            mother.Weight -= baby.Weight * 1.25;

            // Feed the baby.                
            this.FeedNewborn(mother, baby as IEater);

            return baby;
        }

        /// <summary>
        /// Feeds a baby eater.
        /// </summary>
        ///         /// <param name="mother">The mother of the baby.</param>
        /// <param name="newborn">The eater to feed.</param>
        private void FeedNewborn(Animal mother, IEater newborn)
        {
            // Determine milk weight.
            double milkWeight = mother.Weight * 0.005;

            // Generate milk.
            Food milk = new Food(milkWeight);

            // Feed baby.
            newborn.Eat(milk);

            // Reduce parent's weight.
            mother.Weight -= milkWeight;
        }
    }
}
