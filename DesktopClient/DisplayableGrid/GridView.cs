using System.Windows;
using System.Windows.Controls;

namespace JapaneseCrossWord.DisplayableGrid
{
    // TODO: split into more generic grid builder
    public class GridView
    {
        protected readonly Grid _gridSlot;

        public GridView(Grid gridSlot)
        {
            _gridSlot = gridSlot;
        }


        public void BuildGrid(int size)
        {
            BuildEmptyCells(size,size);
        }

        public virtual void BuildGrid(int cols, int rows, bool regenerateProgress = true)
        {
            BuildEmptyCells(cols, rows);
        }

        private void BuildEmptyCells(int cols, int rows)
        {
            BuildColumns(cols);
            BuildRows(rows);
        }

        private void BuildColumns(int count)
        {
            _gridSlot.ColumnDefinitions.Clear();
            for (var i = 0; i < count; i++)
            {
                var column = BuildColumn();
                _gridSlot.ColumnDefinitions.Add(column);
            }
        }

        protected virtual ColumnDefinition BuildColumn()
        {
            return new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
        }

        private void BuildRows(int count)
        {
            _gridSlot.RowDefinitions.Clear();
            for (var i = 0; i < count; i++)
            {
                var row = BuildRow();
                _gridSlot.RowDefinitions.Add(row);
            }
        }

        protected virtual RowDefinition BuildRow()
        {
            return new RowDefinition { Height = new GridLength(1, GridUnitType.Star) };
        }

    }
}