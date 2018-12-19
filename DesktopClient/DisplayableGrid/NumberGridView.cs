using JapaneseCrossword;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DesktopClient.DisplayableGrid
{
    public class NumberGridView : GridView, IHintsGridBuider
    {
        public bool IsVertical { get; }
        private int[,] _gridData;

        public NumberGridView(Grid gridSlot, bool isVertical) : base(gridSlot)
        {
            IsVertical = isVertical;
        }

        public void Build(int[,] GridData)
        {
            Build(GridData.GetLength(1), GridData.GetLength(0));
            FillCells(GridData);
            _gridData = GridData;
        }

        public void FillCells()
        {
            FillCells(_gridData);
        }

        public void FillCells(int[,] GridData)
        {
            // Clear will remain, different impl
            _gridSlot.Children.Clear();
            // Iteration will remain
            for (var row = 0; row < GridData.GetLength(0); row++)
            {
                // Iteration will remain
                for (var col = 0; col < GridData.GetLength(1); col++)
                {
                    // Making a cell will remain, different impl
                    var cellView = new Grid();
                    var content = CreateTextContent(GridData[row, col]);
                    var border = CreateCellBorder(content);
                    cellView.Children.Add(border);

                    // Setting a cell will differ
                    Grid.SetColumn(cellView, col);
                    Grid.SetRow(cellView, row);
                    _gridSlot.Children.Add(cellView);
                }
            }
        }

        // Will differ
        private TextBlock CreateTextContent(int number)
        {
            var cellText = new TextBlock
            {
                Text = SetCellContent(number),
                Background = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Center,
                FontSize = 10,
                TextAlignment = TextAlignment.Center,
            };

            return cellText;
        }

        // will differ
        private Border CreateCellBorder(TextBlock textContent)
        {
            var border = new Border
            {
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Child = textContent,
                Background = Brushes.White,
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(2),

            };

            return border;
        }

        // will differ
        private string SetCellContent(int num)
        {
            if (num == 0)
            {
                return "";
            }

            return num.ToString();
        }

        // Will remain, different implementation
        public void Clear()
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
