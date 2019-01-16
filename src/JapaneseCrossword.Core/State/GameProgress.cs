using JapaneseCrossword.Core.Rules;

namespace JapaneseCrossword.Core.State
{
    public class GameProgress
    {
        public MonochromeCell[,] Goal { get; }
        public MonochromeCell[,] Current { get; }

        public GameProgress(MonochromeCell[,] goal)
        {
            Goal = goal;
            Current = new MonochromeCell[goal.GetLength(0), goal.GetLength(1)];
            InitialiseEmptyCurrentCells();
        }

        public GameProgress(GameStateModel stateModel)
        {
            var monochromes = new MonochromeCell[stateModel.Current.GetLength(0), stateModel.Current.GetLength(1)];
            Goal = BoolToMonochrome(stateModel.Goal);
            Current = BoolToMonochrome(stateModel.Current);
        }

        private MonochromeCell[,] BoolToMonochrome(Fillable [,] fillables)
        {
            var monos = new MonochromeCell[fillables.GetLength(0), fillables.GetLength(1)];
            for (var row = 0; row < fillables.GetLength(0); row++)
            {
                for (var col = 0; col < fillables.GetLength(1); col++)
                {
                    monos[row, col] = new MonochromeCell(fillables[row, col].IsFilled);
                }
            }

            return monos;
        }

        private void InitialiseEmptyCurrentCells()
        {
            for (var row = 0; row < Current.GetLength(0); row++)
            {
                for(var col = 0; col < Current.GetLength(1); col++)
                Current[row, col] = new MonochromeCell();
            }
        }

        public void InvertCell(int row, int col)
        {
            Current[row, col].InvertColor();
        }
    }
}
