using Foods;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent ConsumeBehavior.
    /// </summary>
    public class ConsumeBehavior : IEatBehavior
    {
        /// <summary>
        /// The way the consume behavior eats.
        /// </summary>
        /// <param name="eater"> The animal eating. </param>
        /// <param name="food"> The food they are eating. </param>
        public void Eat(IEater eater, Food food)
        {
            eater.Weight += food.Weight * (eater.WeightGainPercentage / 100);
        }
    }
}
