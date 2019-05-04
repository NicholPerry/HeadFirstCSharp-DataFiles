using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent a SwimBehavior.
    /// </summary>
    public class SwimBehavior : IMoveBehavior
    {
        /// <summary>
        /// The way a swimming animal moves.
        /// </summary>
        /// <param name="animal"> The animal moving. </param>
        public void Move(Animal animal)
        {
            MoveHelper.MoveHorizontally(animal, animal.MoveDistance);
            MoveHelper.MoveVertically(animal, animal.MoveDistance / 2);
        }
    }
}
