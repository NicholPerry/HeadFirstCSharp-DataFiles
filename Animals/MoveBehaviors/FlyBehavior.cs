using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent FlyBehavior.
    /// </summary>
    public class FlyBehavior : IMoveBehavior
    {
        /// <summary>
        /// The way a flying animal moves.
        /// </summary>
        /// <param name="animal"> The animal flying. </param>
        public void Move(Animal animal)
        {
            MoveHelper.MoveHorizontally(animal, animal.MoveDistance);

            if (animal.YDirection == VerticalDirection.Up)
            {
                animal.YPosition += 10;
                animal.YDirection = VerticalDirection.Down;
            }
            else
            {
                animal.YPosition -= 10;
                animal.YDirection = VerticalDirection.Up;
            }
        }
    }
}
