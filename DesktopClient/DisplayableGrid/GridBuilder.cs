using System.Windows;
using System.Windows.Controls;

namespace JapaneseCrossWord.DisplayableGrid
{
    // TODO: split into more generic grid builder
    public class GridBuilder
    {
        protected readonly Grid _gridSlot;
        protected object[,] GridData { set; get; }

        public GridBuilder(Grid gridSlot)
        {
            _gridSlot = gridSlot;
        }


        public void BuildGrid(int size)
        {
            BuildEmptyCells(size,size);
            GridData = new object[size,size];
        }

        public virtual void BuildGrid(int cols, int rows)
        {
            BuildEmptyCells(cols, rows);
        }

        private void BuildEmptyCells(int cols, int rows)
        {
            BuildColumns(cols);
            BuildRows(rows);
            GridData = new object[cols,rows];
        }

        private void BuildColumns(int count)
        {
            _gridSlot.ColumnDefinitions.Clear();
            for (var i = 0; i < count; i++)
            {
                var column = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
                _gridSlot.ColumnDefinitions.Add(column);
            }
        }

        private void BuildRows(int count)
        {
            _gridSlot.RowDefinitions.Clear();
            for (var i = 0; i < count; i++)
            {
                var row = new RowDefinition { Height = new GridLength(1, GridUnitType.Star) };
                _gridSlot.RowDefinitions.Add(row);
            }
        }
    }
}