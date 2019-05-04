using Foods;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent BuryAndEatBoneBehavior.
    /// </summary>
    public class BuryAndEatBoneBehavior : IEatBehavior
    {
        /// <summary>
        /// Method to bury and eat the bone.
        /// </summary>
        /// <param name="eater"> The eater. </param>
        /// <param name="food"> The food being eaten. </param>
        public void Eat(IEater eater, Food food)
        {
            this.BuryBone(food);
            this.DigUpAndEatBone();
            eater.Weight += food.Weight * (eater.WeightGainPercentage / 100);
            this.Bark();
        }

        /// <summary>
        /// Bark upon completion.
        /// </summary>
        private void Bark()
        {
        }

        /// <summary>
        /// Bury the bone.
        /// </summary>
        /// <param name="bone"> The bone being buried. </param>
        private void BuryBone(Food bone)
        {
        }

        /// <summary>
        /// Dig up and eat the bone.
        /// </summary>
        private void DigUpAndEatBone()
        {
        }
    }
}
