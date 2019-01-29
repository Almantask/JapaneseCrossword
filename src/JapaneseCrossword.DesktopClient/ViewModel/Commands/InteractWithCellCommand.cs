using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using JapaneseCrossword.Core.Rules;

namespace JapaneseCrossword.DesktopClient.ViewModel.Commands
{
    internal class InteractWithCellCommand:BaseCommand, ICommand
    {
        private readonly Grid _pixelGrid;

        public InteractWithCellCommand(GameModel model, Grid pixelGrid) : base(model)
        {
            _pixelGrid = pixelGrid;
        }

        public void Execute(object parameter)
        {
            if (model.Crossword == null)
            {
                return;
            }

            var cell = GetCellAtGrid();
            var cellView = GetCellViewAt(cell.Item1, cell.Item2);
            InvertColorOf(cellView);
            var cellLogic = model.Crossword.Current[cell.Item1, cell.Item2];
            model.Crossword.InvertCell(cell.Item1, cell.Item2);
        }

        private Grid GetCellViewAt(int row, int col)
        {
            if (_pixelGrid.Children.Count < 1)
            {
                return new Grid();
            }

            var cellView = _pixelGrid.Children
                .Cast<UIElement>()
                .First(el => Grid.GetRow(el) == row && Grid.GetColumn(el) == col) as Grid;
            return cellView;
        }

        private void InvertColorOf(Grid cellView)
        {
            if (cellView.Background == Brushes.Black)
            {
                cellView.Background = Brushes.White;
            }
            else
            {
                cellView.Background = Brushes.Black;
            }
        }

        private Tuple<int, int> GetCellAtGrid()
        {
            var point = Mouse.GetPosition(_pixelGrid);
            var row = GetRowAtGrid(point.Y);
            var col = GetColAtGrid(point.X);
            return new Tuple<int, int>(row, col);
        }

        private int GetRowAtGrid(double mouseY)
        {
            var row = 0;
            var accumulatedHeight = 0.0;
            foreach (var rowDefinition in _pixelGrid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= mouseY)
                {
                    break;
                }

                row++;
            }

            return row;
        }

        private int GetColAtGrid(double mouseX)
        {
            var col = 0;
            var accumulatedWidth = 0.0;
            foreach (var columnDefinition in _pixelGrid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= mouseX) break;
                col++;
            }

            return col;
        }
    }
}
