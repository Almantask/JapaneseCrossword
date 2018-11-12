using System.Windows.Controls;

namespace JapaneseCrossWord.DisplayableGrid
{
    public abstract class FilledGridBuilder:GridBuilder
    {

        protected FilledGridBuilder(Grid gridSlot) : base(gridSlot)
        {
        }

        public override void BuildGrid(int cols, int rows)
        {
            base.BuildGrid(cols, rows);
            GenerateCellData();
            FillCells();
        }

        public abstract void FillCells();
        public abstract void Clear();
        public abstract void GenerateCellData();
    }
}
