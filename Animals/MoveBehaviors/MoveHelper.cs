using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent MoveHelper.
    /// </summary>
    public static class MoveHelper
    {
        /// <summary>
        /// Moves horizontally across the cage.
        /// </summary>
        /// <param name="animal"> The animal moving. </param>
        /// <param name="moveDistance"> The distance being moved. </param>
        public static void MoveHorizontally(Animal animal, int moveDistance)
        {
            // Pace.
            if (animal.XDirection == HorizontalDirection.Right)
            {
                // If the animal position, and the distance they will move, is less than the max bounds of the window.
                if (animal.XPosition + moveDistance > animal.XPositionMax)
                {
                    // The current position is now the right boundary of the window.
                    animal.XPosition = animal.XPositionMax;

                    // The animal will move left.
                    animal.XDirection = HorizontalDirection.Left;
                }
                else
                {
                    // Move the animal to the right by its step distance.
                    animal.XPosition += moveDistance;
                }
            }
            else
            {
                // Takes the animals current position (right) and subtracts the number of steps to move, if boundary is less than 0...
                if (animal.XPosition - moveDistance < 0)
                {
                    // Boundary position gets set to zero.
                    animal.XPosition = 0;

                    // The animal will move right.
                    animal.XDirection = HorizontalDirection.Right;
                }
                else
                {
                    // Move the animal to the left by its step distance.
                    animal.XPosition -= moveDistance;
                }
            }
        }

        /// <summary>
        /// The method to move the animal vertically across the cage.
        /// </summary>
        /// <param name="animal"> The animal moving. </param>
        /// <param name="moveDistance"> The distance the animal moves. </param>
        public static void MoveVertically(Animal animal, int moveDistance)
        {
            if (animal.YDirection == VerticalDirection.Up)
            {
                if (animal.YPosition - moveDistance < 0)
                {
                    animal.YPosition = 0;
                    animal.YDirection = VerticalDirection.Down;
                }
                else
                {
                    animal.YPosition -= moveDistance;
                }
            }
            else
            {
                if (animal.YPosition + moveDistance > animal.YPositionMax)
                {
                    animal.YPosition = animal.YPositionMax;
                    animal.YDirection = VerticalDirection.Up;
                }
                else
                {
                    animal.YPosition += moveDistance;
                }
            }
        }
    }
}
