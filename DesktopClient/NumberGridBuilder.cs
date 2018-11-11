using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace JapaneseCrossWord
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

        public override void FillCells(int cols, int rows)
        {
            for (var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    var cellView = new Grid();
                    var cellText = new TextBlock
                    {
                        Text = GetRandomCellContent(),
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

        private string GetRandomCellContent()
        {
            var num = GetRandomNumber();
            if (num == 0) return "";
            return num.ToString();
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
