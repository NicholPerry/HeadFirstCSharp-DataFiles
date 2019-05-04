using Foods;

namespace Animals
{
    /// <summary>
    /// The interface which is used to represent IEatBehavior.
    /// </summary>
    public interface IEatBehavior
    {
        /// <summary>
        /// The eat method.
        /// </summary>
        /// <param name="eater"> The animal eating. </param>
        /// <param name="food"> The food they are eating. </param>
        void Eat(IEater eater, Food food);
    }
}
