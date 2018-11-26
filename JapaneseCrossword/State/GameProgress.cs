using JapaneseCrossword.Rules;

namespace JapaneseCrossword.State
{
    public class GameProgress
    {
        public MonochromeCell[,] Goal { get; }
        public MonochromeCell[,] Current { get; }

        public GameProgress(MonochromeCell[,] goal)
        {
            Goal = goal;
            Current = new MonochromeCell[goal.GetLength(0), goal.GetLength(1)];
        }

        public void InvertCell(int row, int col)
        {
            Current[row, col].InvertColor();
        }
    }
}
