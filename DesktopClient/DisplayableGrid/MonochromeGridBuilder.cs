using System;
using System.Windows.Controls;
using System.Windows.Media;

namespace JapaneseCrossWord.DisplayableGrid
{
    public class MonochromeGridBuilder:FilledGridBuilder
    {
        public MonochromeGridBuilder(Grid gridSlot):base(gridSlot)
        {
        }

        public override void FillCells()
        {
            for (var row = 0; row < GridData.GetLength(0); row++)
            {
                for (var col = 0; col < GridData.GetLength(1); col++)
                {
                    var cellView = new Grid
                    {
                        Background = GetColor((int)GridData[row, col])
                    };

                    Grid.SetColumn(cellView, col);
                    Grid.SetRow(cellView, row);
                    _gridSlot.Children.Add(cellView);
                }
            }
        }

        public override void Clear()
        {
            var cols = _gridSlot.ColumnDefinitions.Count;
            var rows = _gridSlot.RowDefinitions.Count;

            _gridSlot.Children.Clear();

            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    var cellView = new Grid
                    {
                        Background = Brushes.White
                    };

                    Grid.SetColumn(cellView, col);
                    Grid.SetRow(cellView, row);
                    _gridSlot.Children.Add(cellView);
                }
            }
        }

        private Brush GetColor(int colorIndex)
        {
            return colorIndex == 0 ? Brushes.White : Brushes.Black;
        }
    }
}
