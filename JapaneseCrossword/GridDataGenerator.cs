using System;
using JapaneseCrossword.Core.Rules;

namespace JapaneseCrossword.Core
{
    public class GridDataGenerator
    {
        private Random _randomiser = new Random();
        private const int IsFilledLiteral = 1;
        private const int IsEmptyLiteral = 0;

        public  MonochromeCell[,] Generate(int cols, int rows)
        {
            var gridData = new MonochromeCell[rows,cols];
            for (var row = 0; row < gridData.GetLength(0); row++)
            {
                for (var col = 0; col < gridData.GetLength(1); col++)
                {
                    var rnNum = _randomiser.Next(IsEmptyLiteral, IsFilledLiteral + 1);
                    gridData[row, col] = new MonochromeCell(rnNum == IsFilledLiteral);
                }
            }

            return gridData;
        }
    }
}
