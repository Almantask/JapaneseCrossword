using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JapaneseCrossWord
{
    public abstract class FilledGridBuilder:GridBuilder
    {

        protected FilledGridBuilder(Grid gridSlot) : base(gridSlot)
        {
        }

        public override void BuildGrid(int cols, int rows)
        {
            base.BuildGrid(cols, rows);
            FillCells(cols, rows);
        }

        public abstract void FillCells(int cols, int rows);
        public abstract void Clear();
    }
}
