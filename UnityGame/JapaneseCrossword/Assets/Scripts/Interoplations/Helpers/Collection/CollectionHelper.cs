using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Helpers.Collection
{
    class CollectionHelper
    {
        #region Helpers for diffferent collections
        /// <summary>
        /// Expands array by 1 position
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="arrayFrom"></param>
        /// <returns></returns>
        public static T[] ExpandArray<T>(T[] arrayFrom)
        {
            T[] newArray = new T[arrayFrom.Length + 1];
            for (int i = 0; i < arrayFrom.Length; i++)
            {
                newArray[i] = arrayFrom[i];
            }
            return newArray;
        }

        /// <summary>
        /// Creates an empty 2D array (non-jagged)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dimensionX"></param>
        /// <param name="dimensionY"></param>
        /// <returns></returns>
        public static T[][] Create2DArray<T>(int dimensionX, int dimensionY)
        {
            T[][] array = new T[dimensionY][];
            for (int i = 0; i < dimensionY; i++)
            {
                array[i] = new T[dimensionX];
            }
            return array;
        }

        public static T[][] FillArrayWithObjects<T>(int arrayWidth, T[] objectsToBePut, T[][] arrayToBeFilled)
        {
            for (int i = 0; i < objectsToBePut.Length; i++)
            {
                int currentXDimensionToBeFilled = i % arrayWidth;
                int currentYDiensionToBeFilled = i / arrayWidth;
                arrayToBeFilled[currentYDiensionToBeFilled][currentXDimensionToBeFilled] = objectsToBePut[i];
            }
            return arrayToBeFilled;
        }
        #endregion
    }
}
