using System.Collections.Generic;
using System.Diagnostics;
using Animals;

namespace Zoos
{
    /// <summary>
    /// The class which is used to represent the SortHelper.
    /// </summary>
    public static class SortHelper
    {
        /// <summary>
        /// Bubble sort by animal name.
        /// </summary>
        /// <param name="animals"> The animal list. </param>
        /// <returns> Returns the result. </returns>
        public static SortResult BubbleSortByName(List<Animal> animals)
        {
            int swapCounter = 0;
            int compareCounter = 0;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            // use a for loop to loop backward through the list
            for (int i = animals.Count - 1; i > 0; i--)
            {
                // loop forward as long as the loop variable is less than the outer loop variable
                for (int j = 0; j < i; j++)
                {
                    compareCounter++;

                    int compare = string.Compare(animals[j].Name, animals[j + 1].Name);

                    if (compare > 0)
                    {
                        Swap(animals, j, j + 1);
                        swapCounter++;
                    }
                }
            }

            stopwatch.Stop();

            SortResult result = new SortResult()
            {
                SwapCount = swapCounter,
                Animals = animals,
                CompareCount = compareCounter,
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
            };

            return result;
        }

        /// <summary>
        /// Bubble sort the animal list by weight.
        /// </summary>
        /// <param name="animals"> The list of animals sorting. </param>
        /// <returns> Returns the result. </returns>
        public static SortResult BubbleSortByWeight(List<Animal> animals)
        {            
            int swapCounter = 0;
            int compareCounter = 0;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            // use a for loop to loop backward through the list
            for (int i = animals.Count - 1; i > 0; i--)
            {
                // loop forward as long as the loop variable is less than the outer loop variable
                for (int j = 0; j < i; j++)
                {
                    compareCounter++;

                    if (animals[j].Weight > animals[j + 1].Weight)
                    {
                        Swap(animals, j, j + 1);
                        swapCounter++;
                    }
                }
            }

            stopwatch.Stop();

            SortResult result = new SortResult()
            {
                SwapCount = swapCounter,
                Animals = animals,
                CompareCount = compareCounter,
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
            };

            return result;
        }

        /// <summary>
        /// Selection sort the animal list by name.
        /// </summary>
        /// <param name="animals"> The list of animals to sort. </param>
        /// <returns> Returns the result. </returns>
        public static SortResult SelectionSortByName(List<Animal> animals)
        {
            int swapCounter = 0;
            int compareCounter = 0;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            for (int i = 0; i < animals.Count - 1; i++)
            {
                Animal minAnimal = animals[i];

                for (int j = i + 1; j < animals.Count; j++)
                {
                    compareCounter++;

                    int compare = string.Compare(animals[j].Name, minAnimal.Name);

                    if (compare < 0)
                    {
                        minAnimal = animals[j];
                    }
                }

                if (animals[i].Weight != minAnimal.Weight)
                {
                    Swap(animals, i, animals.IndexOf(minAnimal));
                    swapCounter++;
                }
            }

            stopwatch.Stop();

            SortResult result = new SortResult()
            {
                SwapCount = swapCounter,
                Animals = animals,
                CompareCount = compareCounter,
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
            };

            return result;
        }

        /// <summary>
        /// Selection sort the list of animals by weight.
        /// </summary>
        /// <param name="animals"> The list of animals to sort. </param>
        /// <returns> Returns the result. </returns>
        public static SortResult SelectionSortByWeight(List<Animal> animals)
        {
            int swapCounter = 0;
            int compareCounter = 0;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            for (int i = 0; i < animals.Count - 1; i++)
            {
                Animal minAnimal = animals[i];

                for (int j = i + 1; j < animals.Count; j++)
                {
                    compareCounter++;

                    if (animals[j].Weight < minAnimal.Weight)
                    {
                        minAnimal = animals[j];
                    }
                }

                if (animals[i].Weight != minAnimal.Weight)
                {
                    Swap(animals, i, animals.IndexOf(minAnimal));
                    swapCounter++;
                }
            }

            stopwatch.Stop();

            SortResult result = new SortResult()
            {
                SwapCount = swapCounter,
                Animals = animals,
                CompareCount = compareCounter,
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
            };

            return result;
        }

        /// <summary>
        /// Insertion sort the list of animals by name.
        /// </summary>
        /// <param name="animals"> The list of animals to sort. </param>
        /// <returns> Returns the result. </returns>
        public static SortResult InsertionSortByName(List<Animal> animals)
        {
            int swapCounter = 0;
            int compareCounter = 0;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            for (int i = 1; i < animals.Count; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    compareCounter++;

                    int compare = string.Compare(animals[j].Name, animals[j - 1].Name);

                    if (compare < 0)
                    {
                        Swap(animals, j, j - 1);
                        swapCounter++;
                    }
                }
            }

            stopwatch.Stop();

            SortResult result = new SortResult()
            {
                SwapCount = swapCounter,
                Animals = animals,
                CompareCount = compareCounter,
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
            };

            return result;
        }

        /// <summary>
        /// Insertion sort the list of animals by weight. 
        /// </summary>
        /// <param name="animals"> The list of animals to sort. </param>
        /// <returns> Returns the result. </returns>
        public static SortResult InsertionSortByWeight(List<Animal> animals)
        {
            int swapCounter = 0;
            int compareCounter = 0;
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            for (int i = 1; i < animals.Count; i++)
            {
                compareCounter++;

                for (int j = i; j > 0 && animals[j].Weight < animals[j - 1].Weight; j--)
                {
                    Swap(animals, j, j - 1);
                    swapCounter++;
                }
            }

            stopwatch.Stop();

            SortResult result = new SortResult()
            {
                SwapCount = swapCounter,
                Animals = animals,
                CompareCount = compareCounter,
                ElapsedMilliseconds = stopwatch.ElapsedMilliseconds,
            };

            return result;
        }

        /// <summary>
        /// Swap the animal position in the list.
        /// </summary>
        /// <param name="animals"> The list of animals. </param>
        /// <param name="index1"> The first position being swapped. </param>
        /// <param name="index2"> The second position being swapped. </param>
        private static void Swap(List<Animal> animals, int index1, int index2)
        {
            Animal position = animals[index1];
            animals[index1] = animals[index2];
            animals[index2] = position;
        }
    }
}
