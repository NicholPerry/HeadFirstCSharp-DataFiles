using Reproducers;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent an eagle.
    /// </summary>
    public class Eagle : Bird
    {
        /// <summary>
        /// Initializes a new instance of the Eagle class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        /// <param name="gender">The gender of the animal.</param>
        public Eagle(string name, int age, double weight, Gender gender)
        : base(name, age, weight, gender)
        {
            this.BabyWeightPercentage = 25.0;
        }
    }
}
