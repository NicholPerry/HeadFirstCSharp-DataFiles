using Reproducers;

namespace People
{
    /// <summary>
    /// The class which is used to represent a restroom.
    /// </summary>
    public class Restroom
    {
        /// <summary>
        /// The maximum number of people allowed in the restroom at a given time.
        /// </summary>
        private int capacity;

        /// <summary>
        /// The gender of the restroom.
        /// </summary>
        private Gender gender;

        /// <summary>
        /// Initializes a new instance of the Restroom class.
        /// </summary>
        /// <param name="capacity">The maximum number of people allowed in the restroom at a given time.</param>
        /// <param name="gender">The gender of the restroom.</param>
        public Restroom(int capacity, Gender gender)
        {
            this.capacity = capacity;
            this.gender = gender;
        }
    }
}