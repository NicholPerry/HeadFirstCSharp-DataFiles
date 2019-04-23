namespace Foods
{
    /// <summary>
    /// The interface which is used to define the role of an eater.
    /// </summary>
    public interface IEater
    {
        /// <summary>
        /// Gets the weight of the eater.
        /// </summary>
        double Weight { get; }

        /// <summary>
        /// Eats the specified food.
        /// </summary>
        /// <param name="food">The food to eat.</param>
        void Eat(Food food);
    }
}