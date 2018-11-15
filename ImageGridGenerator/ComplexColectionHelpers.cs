using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageGridGenerator
{
    public static class ComplexColectionHelpers
    {
        public static int[,] ListArrayToJaggedArray(List<int>[] listArray)
        {
            var maxCount = GetBiggestListCount(listArray);
            var jaggedArray = new int[maxCount, listArray.Length];
            for (var row = 0; row < listArray.Length; row++)
            {
                var columns = listArray[row];
                for (var col = 0; col < columns.Count; col++)
                {
                    jaggedArray[col, row] = columns[col];
                }
            }

            return jaggedArray;
        }

        private static int GetBiggestListCount(List<int>[] arrayList)
        {
            var maxCount = 0;
            foreach (var list in arrayList)
            {
                if (list.Count > maxCount)
                    maxCount = list.Count;
            }

            return maxCount;
        }
    }
}
