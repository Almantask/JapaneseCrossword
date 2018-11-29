using JapaneseCrossword.Rules;

namespace JapaneseCrossword.State
{
    public class GameProgress
    {
        public IMonochrome[,] Goal { get; }
        public IMonochrome[,] Current { get; }

        public GameProgress(IMonochrome[,] goal)
        {
            Goal = goal;
            Current = new IMonochrome[goal.GetLength(0), goal.GetLength(1)];
            InitialiseEmptyCurrentCells();
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
