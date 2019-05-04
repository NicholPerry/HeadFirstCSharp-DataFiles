using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent NoMoveBehavior.
    /// </summary>
    public class NoMoveBehavior : IMoveBehavior
    {
        /// <summary>
        /// The class which is used to represent NoMoveBehavior.
        /// </summary>
        /// <param name="animal"> The animal passed in. </param>
        public void Move(Animal animal)
        {
            // Animal is standing still.
        }
    }
}
