using System;
using System.Collections.Generic;
using CagedItems;

namespace Zoos
{
    /// <summary>
    /// The class which is used to represent a cage.
    /// </summary>
    public class Cage
    {
        /// <summary>
        /// A list of all caged items.
        /// </summary>
        private List<ICageable> cagedItems;

        /// <summary>
        /// Initializes a new instance of the Cage class.
        /// </summary>
        /// <param name="height"> The height of the cage.</param>
        /// <param name="width"> The width of the cage.</param>
        /// <param name="animalType"> The type of animal the cage contains.</param>
        public Cage(int height, int width, Type animalType)
        {
            this.cagedItems = new List<ICageable>();
            this.Height = height;
            this.Width = width;
            this.AnimalType = animalType;
        }

        /// <summary>
        /// Gets the value for the animal type.
        /// </summary>
        public Type AnimalType { get; private set; }

        /// <summary>
        /// Gets the value for the height.
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Gets the value for the width.
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Gets the list of caged items.
        /// </summary>
        public IEnumerable<ICageable> CagedItems
        {
            get
            {
                return this.cagedItems;
            }
        }

        /// <summary>
        /// Adds a caged item to the list.
        /// </summary>
        /// <param name="cagedItem"> The item to add.</param>
        public void Add(ICageable cagedItem)
        {
            this.cagedItems.Add(cagedItem);
        }

        /// <summary>
        /// Removes the caged item from the cage.
        /// </summary>
        /// <param name="cagedItem"> The item to be removed.</param>
        public void Remove(ICageable cagedItem)
        {
            this.cagedItems.Remove(cagedItem);
        }

        /// <summary>
        /// Over rides the To String.
        /// </summary>
        /// <returns> Returns the value.</returns>
        public override string ToString()
        {
            string result = null;

            result = string.Format("{0} {1} ({2}x{3})", this.AnimalType.Name, "cage", this.Width, this.Height);

            foreach (ICageable c in this.cagedItems)
            {
                result += string.Format("{0} {1} ({2}x{3})", Environment.NewLine, c, c.XPosition, c.YPosition);
            }

            return result;
        }
    }
}
