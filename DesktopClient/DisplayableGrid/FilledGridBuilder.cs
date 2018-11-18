using System.Windows.Controls;

namespace JapaneseCrossWord.DisplayableGrid
{
    public abstract class FilledGridBuilder:GridBuilder
    {
        public int[,] GridData { set; get; }

        protected FilledGridBuilder(Grid gridSlot) : base(gridSlot)
        {
        }

        public override void BuildGrid(int cols, int rows)
        {
            base.BuildGrid(cols, rows);
            FillCells();
        }

        public abstract void FillCells();
        public abstract void Clear();
    }
}
