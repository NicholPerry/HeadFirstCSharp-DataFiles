using Animals;
using Reproducers;

namespace Toys
{
    /// <summary>
    /// The class which is used to represent a WuvLuv.
    /// </summary>
    public class WuvLuv : IHatchable, IReproducer
    {
        /// <summary>
        /// The price of the WuvLuv.
        /// </summary>
        private readonly decimal price = 19.99m;

        /// <summary>
        /// The color of the WuvLuv.
        /// </summary>
        private string color;

        /// <summary>
        /// A value indicating whether or not the WuvLuv is in a state in which it can lay an egg.
        /// </summary>
        private bool isPregnant;

        /// <summary>
        /// Initializes a new instance of the WuvLuv class.
        /// </summary>
        /// <param name="color">The color of the WuvLuv.</param>
        public WuvLuv(string color)
        {
            this.color = color;
        }

        /// <summary>
        /// Gets a value indicating whether or not the WuvLuv is in a state in which it can lay an egg.
        /// </summary>
        public bool IsPregnant
        {
            get
            {
                return this.isPregnant;
            }
        }

        /// <summary>
        /// Gets the price of the WuvLuv.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }
        }

        /// <summary>
        /// Hatches from its egg.
        /// </summary>
        public void Hatch()
        {
            // Break out of egg.
        }

        /// <summary>
        /// Puts the WuvLuv is in a state in which it can lay an egg.
        /// </summary>
        public void MakePregnant()
        {
            this.isPregnant = true;
        }

        /// <summary>
        /// Creates another reproducer of its own type.
        /// </summary>
        /// <returns>The resulting baby reproducer.</returns>
        public IReproducer Reproduce()
        {
            // Lay an egg.
            IReproducer result = new WuvLuv(this.color);

            // If the baby is hatchable...
            if (result is IHatchable)
            {
                // Hatch the baby out of its egg.
                (result as IHatchable).Hatch();
            }

            // Return the (hatched) baby.
            return result;
        }
    }
}