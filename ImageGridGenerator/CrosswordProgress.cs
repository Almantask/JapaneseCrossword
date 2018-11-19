using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGenerator
{
    public class CrosswordProgress
    {
        public int[,] _goalGrid;
        public int[,] _currentGrid;

        public CrosswordProgress(int[,] goalGrid)
        {
            _goalGrid = goalGrid;
            _currentGrid = new int[_goalGrid.GetLength(0),_goalGrid.GetLength(1)];
        }

        public CrosswordProgress(int cols, int rows)
        {
            _goalGrid = GenerateGoalGrid(cols, rows);
            _currentGrid = new int[_goalGrid.GetLength(0), _goalGrid.GetLength(1)];
        }

        private int[,] GenerateGoalGrid(int cols, int rows)
        {
            GridDataGenerator generator = new GridDataGenerator();
            return generator.Generate(cols, rows, 0, 1);
        }

        public bool IsDone()
        {
            var goal = _goalGrid.Cast<int>();
            var current = _currentGrid.Cast<int>();
            return goal.SequenceEqual(current);
        }
    }
}
