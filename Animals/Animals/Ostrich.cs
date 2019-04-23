using Reproducers;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent an ostrich.
    /// </summary>
    public sealed class Ostrich : Bird
    {
        /// <summary>
        /// Initializes a new instance of the Ostrich class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        /// <param name="gender">The gender of the animal.</param>
        public Ostrich(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            this.BabyWeightPercentage = 30.0;
        }

        /// <summary>
        /// Gets the display size.
        /// </summary>
        public override double DisplaySize
        {
            get
            {
                return this.Age == 0 ? 0.4 : 0.8;
            }
        }

        /// <summary>
        /// Moves by pacing.
        /// </summary>
        public override void Move()
        {
            // Moves by pacing; the ostrich will not fly.
            // Pace.
            if (this.XDirection == HorizontalDirection.Right)
            {
                // If the animal position, and the distance they will move, is less than the max bounds of the window.
                if (this.XPosition + this.MoveDistance > this.XPositionMax)
                {
                    // The current position is now the right boundary of the window.
                    this.XPosition = this.XPositionMax;

                    // The animal will move left.
                    this.XDirection = HorizontalDirection.Left;
                }
                else
                {
                    // Move the animal to the right by its step distance.
                    this.XPosition += this.MoveDistance;
                }
            }
            else
            {
                // Takes the animals current position (right) and subtracts the number of steps to move, if boundary is less than 0...
                if (this.XPosition - this.MoveDistance < 0)
                {
                    // Boundary position gets set to zero.
                    this.XPosition = 0;

                    // The animal will move right.
                    this.XDirection = HorizontalDirection.Right;
                }
                else
                {
                    // Move the animal to the left by its step distance.
                    this.XPosition -= this.MoveDistance;
                }
            }
        }
    }
}
