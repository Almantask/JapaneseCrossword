using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JapaneseCrossWord.DisplayableGrid
{
    // TODO: refactor grid builders
    public class NumberGridView:FilledGridView
    {
        public bool IsVertical { get; }

        public NumberGridView(Grid gridSlot, bool isVertical):base(gridSlot)
        {
            IsVertical = isVertical;
        }

        public NumberGridView(Grid gridSlot, bool isVertical, int[,] gridData) : base(gridSlot)
        {
            IsVertical = isVertical;
            GridData = gridData;
        }

        public override void FillCells()
        {
            if (GridData == null) return;
            _gridSlot.Children.Clear();
            for (var row = 0; row < GridData.GetLength(0); row++)
            {
                for (var col = 0; col < GridData.GetLength(1); col++)
                {
                    var cellView = new Grid();
                    var cellText = new TextBlock
                    {
                        Text = SetCellContent(GridData[row, col]),
                        Background = Brushes.White,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        FontSize = 10,
                        TextAlignment = TextAlignment.Center,
                    };

                    var border = new Border
                    {
                        VerticalAlignment = VerticalAlignment.Stretch,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        Child = cellText,
                        Background = Brushes.White,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(2),
                        
                    };

                    cellView.Children.Add(border);

                    Grid.SetColumn(cellView, col);
                    Grid.SetRow(cellView, row);
                    _gridSlot.Children.Add(cellView);
                }
            }
        }

        private string SetCellContent(int num)
        {
            if (num == 0) return "";
            return num.ToString();
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
    }
}
