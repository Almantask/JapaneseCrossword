using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ImageGridGenerator
{
    public class HintsCalculator
    {
        private const int EmptyElementLiteral = 0;
        private readonly int[,] _cellData;

        public HintsCalculator(int[,] cellData)
        {
            _cellData = cellData;
        }

        public int[,] CalculateVerticalHints()
        {
            var hints = GetConsequitiveVerticalElements();
            return ComplexColectionHelpers.ListArrayToJaggedArray(hints);
        }

        public int[,] CalculateHorizontalHints()
        {
            var hints = GetConsequitiveHorizontalElements();
            return ComplexColectionHelpers.ListArrayToJaggedArray(hints);
        }

        private List<int>[] GetConsequitiveVerticalElements()
        {
            var hintsPerRow = new List<int>[_cellData.GetLength(0)];
            for (var row = 0; row < _cellData.GetLength(1); row++)
            {
                var rowElements = GetRowElements(row);
                var counts = GetConsequitiveElementsCounts(rowElements);
                hintsPerRow[row] = counts;
            }

            return hintsPerRow;
        }

        private List<int>[] GetConsequitiveHorizontalElements()
        {
            var hintsPerCol = new List<int>[_cellData.GetLength(1)];
            for (var col = 0; col < _cellData.GetLength(0); col++)
            {
                var rowElements = GetColumnElements(col);
                var counts = GetConsequitiveElementsCounts(rowElements);
                hintsPerCol[col] = counts;
            }

            return hintsPerCol;
        }

        private int[] GetColumnElements(int col)
        {
            var columnElements = new int[_cellData.GetLength(1)];
            for (var row = 0; row < _cellData.GetLength(1); row++)
            {
                columnElements[row] = _cellData[col, row];
            }

            return columnElements;
        }

        private int[] GetRowElements(int row)
        {
            var rowElements = new int[_cellData.GetLength(0)];
            for (var col = 0; col < _cellData.GetLength(0); col++)
            {
                rowElements[col] = _cellData[col, row];
            }

            return rowElements;
        }

        private List<int> GetConsequitiveElementsCounts(int[] elements)
        {
            var consequitiveElementsCounts = new List<int>();
            var count = 1;
            var index = 0;
            for (; index < elements.Length - 1; index++)
            {
                if (elements[index] == EmptyElementLiteral) continue;
                if (elements[index] == elements[index + 1])
                    count++;
                else
                {
                    consequitiveElementsCounts.Add(count);
                    count = 1;
                }
            }

            return consequitiveElementsCounts;
        }
    }
}
