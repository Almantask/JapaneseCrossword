using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace JapaneseCrossWord
{
    // TODO: split into more generic grid builder
    internal class MonochromeGridBuilder
    {
        private readonly Grid _pixelGrid;
        private readonly Random _randomiser;


        public MonochromeGridBuilder(Grid pixelGrid)
        {
            _randomiser = new Random();
            this._pixelGrid = pixelGrid;
        }


        public void BuildGrid(int size)
        {
            
            BuildEmptyCells(size,size);
            FillCells(size, size);
        }

        public void BuildGrid(int cols, int rows)
        {

            BuildEmptyCells(cols, rows);
            FillCells(cols, rows);
        }

        public void BuildGrid(BitmapImage image)
        {
            //BuildEmptyCells(cols, rows);
            //FillCells(cols, rows);
        }

        private void BuildEmptyCells(int cols, int rows)
        {
            BuildColumns(cols);
            BuildRows(rows);
        }

        private void BuildRows(int count)
        {
            _pixelGrid.ColumnDefinitions.Clear();
            for (var i = 0; i < count; i++)
            {
                var column = new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) };
                _pixelGrid.ColumnDefinitions.Add(column);

            }
        }

        private void BuildColumns(int count)
        {
            _pixelGrid.RowDefinitions.Clear();
            for (var i = 0; i < count; i++)
            {
                var row = new RowDefinition { Height = new GridLength(1, GridUnitType.Star) };
                _pixelGrid.RowDefinitions.Add(row);
            }
        }

        private void FillCells(int cols, int rows)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    var cellView = new DockPanel
                    {
                        Background = GetRandomColor(),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };

                    Grid.SetColumn(cellView, row);
                    Grid.SetRow(cellView, col);
                    _pixelGrid.Children.Add(cellView);
                }
            }
        }

        private Brush GetRandomColor()
        {
            var num = _randomiser.Next(0, 2);
            if (num > 0)
                return Brushes.Black;
            return Brushes.White;
        }
    }
}