using System.Drawing;
using System.Windows.Controls;
using GridGenerator;
using JapaneseCrossWord.Views;
using Brush = System.Windows.Media.Brush;
using Brushes = System.Windows.Media.Brushes;

namespace JapaneseCrossWord.DisplayableGrid
{
    public class MonochromeGridView:FilledGridView
    {
        public int[,] Progress => GameProgress._currentGrid;

        private CrosswordProgress _gameProgress;
        public CrosswordProgress GameProgress
        {
            set
            {
                GridData = value._goalGrid;
                _gameProgress = value;
            }
            get => _gameProgress;
        }

        public MonochromeGridView(Grid gridSlot):base(gridSlot)
        {
        }

        public override void FillCells()
        {
            _gridSlot.Children.Clear();
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

        public void FillProgressCells()
        {
            BuildGrid(GridData.GetLength(1), GridData.GetLength(0));
            _gridSlot.Children.Clear();
            for (var row = 0; row < _gameProgress._currentGrid.GetLength(0); row++)
            {
                for (var col = 0; col < _gameProgress._currentGrid.GetLength(1); col++)
                {
                    var cellView = new Grid
                    {
                        Background = GetColor((int)_gameProgress._currentGrid[row, col])
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

        protected override RowDefinition BuildRow()
        {
            var row = base.BuildRow();
            return row;
        }

        protected override ColumnDefinition BuildColumn()
        {
            var col = base.BuildColumn();
            return col;
        }

        public void ColorGrid(bool isWhite)
        {
            foreach (var child in _gridSlot.Children)
                ((Grid) child).Background = isWhite ? Brushes.White : Brushes.Black;
        }

        public override void BuildGrid(int cols, int rows)
        {
            GameProgress = new CrosswordProgress(cols, rows);
            base.BuildGrid(cols, rows);
            ColorGrid(true);
        }
    }
}
