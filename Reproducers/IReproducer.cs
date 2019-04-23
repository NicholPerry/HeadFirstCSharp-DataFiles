namespace Reproducers
{
    /// <summary>
    /// The interface which is used to define the role of a reproducer.
    /// </summary>
    public interface IReproducer
    {
        /// <summary>
        /// Gets a value indicating whether or not the reproducer is pregnant.
        /// </summary>
        bool IsPregnant { get; }

        /// <summary>
        /// Makes the reproducer pregnant.
        /// </summary>
        void MakePregnant();

        /// <summary>
        /// Creates another reproducer of its own type.
        /// </summary>
        /// <returns>The resulting baby reproducer.</returns>
        IReproducer Reproduce();
    }
}