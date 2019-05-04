using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The interface which is used to represent IMoveBehavior.
    /// </summary>
    public interface IMoveBehavior
    {
        /// <summary>
        /// The behavior to move.
        /// </summary>
        /// <param name="animal"> The animal moving. </param>
        void Move(Animal animal);
    }
}
