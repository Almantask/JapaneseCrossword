using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossword.Core.Extensions
{
    public static class JaggedArrayExtensions
    {
        public static T[] GetRowElements<T>(this T[,] array, int row)
        {
            var rowElements = new T[array.GetLength(1)];
            for (var col = 0; col < array.GetLength(1); col++)
            {
                rowElements[col] = array[row, col];
            }

            return rowElements;
        }

        public static T[] GetColElements<T>(this T[,] array, int col)
        {
            var columnElements = new T[array.GetLength(0)];
            for (var row = 0; row < array.GetLength(0); row++)
            {
                columnElements[row] = array[row, col];
            }

            return columnElements;
        }
    }
}
