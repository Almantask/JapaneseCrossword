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
        private const int FilledElementLiteral = 1;
        private readonly int[,] _cellData;

        public HintsCalculator(int[,] cellData)
        {
            _cellData = cellData;
        }

        // TODO: rows and columns mixed
        public int[,] CalculateVerticalHints()
        {
            var hints = GetConsecuitiveVerticalElements();
            return ComplexColectionHelpers.ListArrayToJaggedArrayVertical(hints);
        }

        public int[,] CalculateHorizontalHints()
        {
            var hints = GetConsecuitiveHorizontalElements();
            return ComplexColectionHelpers.ListArrayToJaggedArrayHorizontal(hints);
        }

        public List<int>[] GetConsecuitiveVerticalElements()
        {
            var hintsPerCol = new List<int>[_cellData.GetLength(1)];
            for (var col = 0; col < _cellData.GetLength(1); col++)
            {
                var rowElements = GetColumnElements(col);
                var counts = GetConsecuitiveElementsCounts(rowElements);
                hintsPerCol[col] = counts;
            }

            return hintsPerCol;
        }

        public List<int>[] GetConsecuitiveHorizontalElements()
        {
            var hintsPerRow = new List<int>[_cellData.GetLength(0)];
            for (var row = 0; row < _cellData.GetLength(0); row++)
            {
                var rowElements = GetRowElements(row);
                var counts = GetConsecuitiveElementsCounts(rowElements);
                hintsPerRow[row] = counts;
            }

            return hintsPerRow;
        }

        private int[] GetColumnElements(int col)
        {
            var columnElements = new int[_cellData.GetLength(0)];
            for (var row = 0; row < _cellData.GetLength(0); row++)
            {
                columnElements[row] = _cellData[row, col];
            }

            return columnElements;
        }

        private int[] GetRowElements(int row)
        {
            var rowElements = new int[_cellData.GetLength(1)];
            for (var col = 0; col < _cellData.GetLength(1); col++)
            {
                rowElements[col] = _cellData[row, col];
            }

            return rowElements;
        }

        private List<int> GetConsecuitiveElementsCounts(int[] elements)
        {
            var ConsecuitiveElementsCounts = new List<int>();
            var count = 0;
            for (var index = 0; index < elements.Length; index++)
            {
                if (elements[index] == FilledElementLiteral)
                {
                    if (count == 0)
                    {
                        count++;
                    }
                    else if (elements[index] == elements[index - 1])
                    {
                        count++;
                    }
                }
                else if(count != 0)
                {
                    ConsecuitiveElementsCounts.Add(count);
                    count = 0;
                }
            }

            if(count > 0)
                ConsecuitiveElementsCounts.Add(count);

            return ConsecuitiveElementsCounts;
        }
    }
}
