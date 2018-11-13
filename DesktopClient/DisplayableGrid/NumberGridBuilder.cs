﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JapaneseCrossWord.DisplayableGrid
{
    // TODO: refactor grid builders
    public class NumberGridBuilder:FilledGridBuilder
    {
        private readonly Random _randomiser;
        public bool IsVertical { get; }

        public NumberGridBuilder(Grid gridSlot, bool isVertical):base(gridSlot)
        {
            _randomiser = new Random();
            IsVertical = isVertical;
        }

        public NumberGridBuilder(Grid gridSlot, bool isVertical, int[,] gridData) : base(gridSlot)
        {
            _randomiser = new Random();
            IsVertical = isVertical;
            GridData = gridData;
        }

        public override void GenerateCellData()
        {
            if (GridData == null) return;
            for (var col = 0; col < GridData.GetLength(0); col++)
            {
                for (var row = 0; row < GridData.GetLength(1); row++)
                {
                    GridData[col, row] = _randomiser.Next(0, 10);
                }
            }
        }

        public override void FillCells()
        {
            for (var col = 0; col < GridData.GetLength(0); col++)
            {
                for (var row = 0; row < GridData.GetLength(1); row++)
                {
                    var cellView = new Grid();
                    var cellText = new TextBlock
                    {
                        Text = SetCellContent(GridData[col, row]),
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

        private string SetCellContent(object obj)
        {
            if ((int)obj == 0) return "";
            return obj.ToString();
        }

        private int GetRandomNumber()
        {
            var num = _randomiser.Next(0, 2);
            if (num == 0) return num;

            num = _randomiser.Next(0, 10);
            return num;
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
