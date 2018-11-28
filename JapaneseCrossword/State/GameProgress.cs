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
        }

        public void InvertCell(int row, int col)
        {
            Current[row, col].InvertColor();
        }
    }
}
