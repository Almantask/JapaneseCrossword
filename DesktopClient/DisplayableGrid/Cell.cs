using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapaneseCrossWord.DisplayableGrid
{
    struct Cell
    {
        public int Row;
        public int Col;

        public Cell(int row, int col)
        {
            Row = row;
            Col = col;
        }
    }
}
