using Reproducers;

namespace Animals
{
    /// <summary>
    /// The interface which is used to represent IReproduceBehavior.
    /// </summary>
    public interface IReproduceBehavior
    {
        /// <summary>
        /// The way an animal reproduces.
        /// </summary>
        /// <param name="mother"> The mother of the baby. </param>
        /// <param name="baby"> The baby being born. </param>
        /// <returns> Returns the baby. </returns>
        IReproducer Reproduce(Animal mother, Animal baby);
    }
}
