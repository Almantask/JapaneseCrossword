using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JapaneseCrossWord
{
    public partial class MainWindow : Window
    {
        private int _gridSize = 9;
        private readonly Random _randomiser;

        public MainWindow()
        {
            InitializeComponent();
            _randomiser = new Random();
            BuildGrid(_gridSize);
        }

        private void BuildGrid(int size)
        {
            BuildEmptyCells(size);
            FillCells(size);
        }

        private void BuildEmptyCells(int size)
        {
            for (var i = 0; i < size; i++)
            {
                var column = new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star) };
                var row = new RowDefinition {Height = new GridLength(1, GridUnitType.Star) };
                PixelGrid.ColumnDefinitions.Add(column);
                PixelGrid.RowDefinitions.Add(row);
            }
        }

        private void FillCells(int size)
        {
            for (var row = 0; row < size; row++)
            {
                for (var col = 0; col < size; col++)
                {
                    var cellView = new DockPanel
                    {
                        Background = GetRandomColor(),
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                    };

                    Grid.SetColumn(cellView, row);
                    Grid.SetRow(cellView, col);
                    PixelGrid.Children.Add(cellView);
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
