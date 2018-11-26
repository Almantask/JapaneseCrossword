using System;

namespace JapaneseCrossword
{
    public  class GridDataGenerator
    {
        private Random _randomiser = new Random();

        public  int[,] Generate(int cols, int rows, int min, int max)
        {
            var gridData = new int[rows,cols];
            for (var row = 0; row < gridData.GetLength(0); row++)
            {
                for (var col = 0; col < gridData.GetLength(1); col++)
                {
                    gridData[row, col] = _randomiser.Next(min, max+1);
                }
            }

            return gridData;
        }
    }
}
