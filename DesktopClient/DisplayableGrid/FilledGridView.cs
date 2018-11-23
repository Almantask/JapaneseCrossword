using System.Windows.Controls;

namespace JapaneseCrossWord.DisplayableGrid
{
    public abstract class FilledGridView:GridView
    {
        public int[,] GridData { set; get; }

        protected FilledGridView(Grid gridSlot) : base(gridSlot)
        {
        }

        public override void BuildGrid(int cols, int rows, bool regenerateProgress = true)
        {
            base.BuildGrid(cols, rows);
            FillCells();
        }

        public abstract void FillCells();
        public abstract void Clear();
    }
}
