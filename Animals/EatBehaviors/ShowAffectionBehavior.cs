using Foods;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent ShowAffectionBehavior.
    /// </summary>
    public class ShowAffectionBehavior : IEatBehavior
    {
        /// <summary>
        /// The method to eat.
        /// </summary>
        /// <param name="eater"> The animal eating. </param>
        /// <param name="food"> The food being eaten. </param>
        public void Eat(IEater eater, Food food)
        {
            eater.Weight += food.Weight * (eater.WeightGainPercentage / 100);
            this.ShowAffection();
        }

        /// <summary>
        /// Show affection after eating.
        /// </summary>
        private void ShowAffection()
        {
        }
    }
}
