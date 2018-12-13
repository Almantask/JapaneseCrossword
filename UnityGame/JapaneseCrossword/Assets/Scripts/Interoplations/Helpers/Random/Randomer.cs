using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Helpers.RandomBasedOperations
{
    namespace RandomHelper
    {
        /// <summary>
        /// Methods for abstract randomisation based on situation
        /// </summary>
        public static class Randomer
        {
            /// <summary>
            /// Gets a random item from a collection without getting the same item. null or 0 if no item with given input exists
            /// </summary>
            /// <typeparam name="T"> Abstract type for collection</typeparam>
            /// <param name="collection"> Collection of abstract type</param>
            /// <param name="usedIndexes"> Indicates collection items that won't be picked</param>
            /// <returns> T if item exists, </returns>
            public static T GetRandom<T>(T[] collection, List<int> usedIndexes)
            {
                int random = Random.Range(0, collection.Length);
                bool isRandomGood = false;
                int wrongCount = 0;
                while (!isRandomGood)
                {
                    isRandomGood = true;
                    for (int i = 0; i < usedIndexes.Count; i++)
                    {
                        if (random == usedIndexes[i])
                        {
                            isRandomGood = false;
                            break;
                        }
                    }
                    if (!isRandomGood)
                    {
                        random = (random + 1) % collection.Length;
                        wrongCount++;
                    }
                    if (wrongCount > collection.Length)
                        return default(T);
                }
                usedIndexes.Add(random);
                T t = collection[random];
                return t;
            }

            /// <summary>
            /// Shuffles a collection
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="collection"> Collection to be shuffled</param>
            /// <param name="cantBeFirstIndex"> Index which cannot be first in the collection. -1 if ignored</param>
            /// <returns></returns>
            public static T[] Shuffle<T>(T[] collection, int cantBeFirstIndex = -1)
            {
                List<int> usedIndexes = new List<int>();
                int count = collection.Length;
                T[] shuffledArray = new T[count];
                int startFrom;

                if (cantBeFirstIndex != -1)
                {
                    T firstElement;
                    int random = Random.Range(0, collection.Length);
                    if (cantBeFirstIndex == random)
                    {
                        firstElement = collection[(collection.Length + 1) % collection.Length];
                    }
                    else
                        firstElement = collection[random];
                    startFrom = 1;
                    shuffledArray[0] = firstElement;
                    usedIndexes.Add(random);
                }
                else
                {
                    startFrom = 0;
                }

                for (int i = startFrom; i < count; i++)
                {
                    shuffledArray[i] = GetRandom<T>(collection, usedIndexes);
                }
                return shuffledArray;
            }

            /// <summary>
            /// Gets a random item from a collection that is not the same as indicated item
            /// </summary>
            /// <typeparam name="T"> Abstract type for collection</typeparam>
            /// <param name="collection"> Collection of abstract type</param>
            /// <param name="usedIndexes"> Indicates an index that cannot be picked</param>
            /// <returns> T if item exists, </returns>
            public static T GetRandom<T>(T[] collection, int i)
            {
                int random = Random.Range(0, collection.Length);
                ICollection col = collection as ICollection;
                if (i == random)
                {
                    return collection[(col.Count + 1) % col.Count];
                }
                else
                    return collection[random];
            }
        }
    }
}

