using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace JapaneseCrossWord
{
    // TODO: split into more generic grid builder
    public class GridBuilder
    {
        protected readonly Grid _gridSlot;


        public GridBuilder(Grid gridSlot)
        {
            _gridSlot = gridSlot;
        }


        public void BuildGrid(int size)
        {
            BuildEmptyCells(size,size);
        }

        public virtual void BuildGrid(int cols, int rows)
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