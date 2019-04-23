namespace Foods
{
    /// <summary>
    /// The class which is used to represent food.
    /// </summary>
    public class Food
    {
        /// <summary>
        /// The weight of the food (in pounds).
        /// </summary>
        private double weight;

        /// <summary>
        /// Initializes a new instance of the Food class.
        /// </summary>
        /// <param name="weight">The weight of the food (in pounds).</param>
        public Food(double weight)
        {
            this.weight = weight;
        }

        /// <summary>
        /// Gets the weight of the food (in pounds).
        /// </summary>
        public double Weight
        {
            get
            {
                return this.weight;
            }
        }
    }
}