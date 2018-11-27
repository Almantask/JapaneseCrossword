using System.Drawing;
using System.Windows.Controls;
using GridGenerator;
using JapaneseCrossword.Rules;
using JapaneseCrossWord.Views;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;

namespace JapaneseCrossWord.DisplayableGrid
{
    public class MonochromeGridView:GridView
    {
        public MonochromeGridView(Grid gridSlot):base(gridSlot)
        {
        }

        public void Clear()
        {
            _gridSlot.Children.Clear();
            ColorWhite();
        }

        private void ColorWhite()
        {
            foreach (var child in _gridSlot.Children)
                ((Grid)child).Background = Brushes.White;
        }

        private Brush GetColor(bool isFilled)
        {
            return isFilled ? Brushes.Black : Brushes.White;
        }

        public override void BuildGrid(int cols, int rows)
        {
            base.BuildGrid(cols, rows);
            FillEmpty();
        }

        private void FillEmpty()
        {
            _gridSlot.Children.Clear();
            for (var row = 0; row < _gridSlot.RowDefinitions.Count; row++)
            {
                for (var col = 0; col < _gridSlot.ColumnDefinitions.Count; col++)
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

        public void BuildGrid(MonochromeCell[,] GridData)
        {
            _gridSlot.Children.Clear();
            BuildGrid(GridData.GetLength(1), GridData.GetLength(0));
            for (var row = 0; row < GridData.GetLength(0); row++)
            {
                for (var col = 0; col < GridData.GetLength(1); col++)
                {
                    var cellView = new Grid
                    {
                        Background = GetColor(GridData[row, col].IsFilled)
                    };

                    Grid.SetColumn(cellView, col);
                    Grid.SetRow(cellView, row);
                    _gridSlot.Children.Add(cellView);
                }
            }
        }

    }
}
