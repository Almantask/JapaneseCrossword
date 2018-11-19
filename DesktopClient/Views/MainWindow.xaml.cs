using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ImageGridGenerator;
using JapaneseCrossWord.DisplayableGrid;
using GridGenerator;

namespace JapaneseCrossWord.Views
{
    public partial class MainWindow : Window
    {
        private readonly MonochromeGridView _pixelGridView;
        private int _preferableGridSize = 9;
        private List<NumberGridView> _numberGridBuilders;
        private bool _isFirstLoad = true;

        public MainWindow()
        {
            InitializeComponent();
            _pixelGridView = new MonochromeGridView(PixelGrid);
            BuilHintGrids();
        }

        private void BuilHintGrids()
        {
            _numberGridBuilders = new List<NumberGridView>();
            Grid[] hintGridsSides = { LeftHintGrid, RightHintGrid };
            Grid[] hintGridsGroundRoof = { TopHintGrid, BottomHintGrid };

            foreach (var hintGrid in hintGridsSides)
            {
                var numberGridBuilder = new NumberGridView(hintGrid, true);
                _numberGridBuilders.Add(numberGridBuilder);
            }
            foreach (var hintGrid in hintGridsGroundRoof)
            {
                var numberGridBuilder = new NumberGridView(hintGrid, false);
                _numberGridBuilders.Add(numberGridBuilder);
            }
        }


        // TODO: MVVM
        private void OnButtonRnadomGrid(object sender, RoutedEventArgs e)
        {
            BuildCrossword();
        }

        private void BuildCrossword()
        {
            var gridSizeInput = textBoxGridSize.Text;
            Tuple<int, int> gridSize = null;
            try
            {
                gridSize = ParseGridSize(gridSizeInput);
            }
            catch
            {
                MessageBox.Show($"Failed to read grid size: {gridSizeInput} is not valid");
                return;
            }

            BuildMainGrid(gridSize.Item1, gridSize.Item2);
            BuildHintGrids();
        }

        /// <summary>
        /// Returns cols and rows in that order
        /// </summary>
        private Tuple<int, int> ParseGridSize(string input)
        {
            var inputSplit = input.Split(',');
            int cols;
            int rows;
            if (inputSplit.Length == 2)
            {
                rows = int.Parse(inputSplit[0]);
                cols = int.Parse(inputSplit[1]);
            }
            else
            {
                rows = int.Parse(input);
                cols = rows;
            }
            return new Tuple<int, int>(cols, rows);
        }

        private void BuildMainGrid(int cols, int rows)
        {
            _pixelGridView.BuildGrid(cols, rows);
        }

        private void BuildHintGrids()
        {
            var hintsCalculator = new HintsCalculator(_pixelGridView.GridData);
            //var verticalHintsGridData = hintsCalculator.CalculateVerticalHints();
            //var horizontalHintsGridData = hintsCalculator.CalculateHorizontalHints();
            var horizontalHintsGridData = hintsCalculator.CalculateVerticalHints().InvertOrientation();
            var verticalHintsGridData = hintsCalculator.CalculateHorizontalHints().InvertOrientation();
            foreach (var hintsGridView in _numberGridBuilders)
            {
                // TODO: refactor
                if (hintsGridView.IsVertical)
                {
                    
                    hintsGridView.GridData = verticalHintsGridData;
                    var rows = verticalHintsGridData.GetLength(0);
                    var cols = verticalHintsGridData.GetLength(1);
                    hintsGridView.BuildGrid(cols, rows);
                }
                else
                {
                    hintsGridView.GridData = horizontalHintsGridData;
                    var rows = horizontalHintsGridData.GetLength(0);
                    var cols = horizontalHintsGridData.GetLength(1);
                    hintsGridView.BuildGrid(cols, rows);
                }
            }
        }

        private void OnButtonImageGridClick(object sender, RoutedEventArgs e)
        {
            BitmapImage image = GetImageFromDialog();
            if (image == null) return;

            _pixelGridView.BuildGrid(_preferableGridSize);
        }

        private BitmapImage GetImageFromDialog()
        {
            Microsoft.Win32.OpenFileDialog fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".png",
                Filter =
                    "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"
            };
            var result = fileDialog.ShowDialog();
            if (result != true) return null;
            var filename = fileDialog.FileName;
            return new BitmapImage(new Uri(filename, UriKind.Absolute));
        }

        private void CheckBoxHintOnOff_OnChecked(object sender, RoutedEventArgs e)
        {
            // Becasue hints are enabled by default
            if (_isFirstLoad)
            {
                _isFirstLoad = false;
            }
            else
            {
                EnableHints();
            }
        }

        private void EnableHints()
        {
            foreach (var numberGridBuilder in _numberGridBuilders)
            {
                if (numberGridBuilder.IsVertical)
                    numberGridBuilder.FillCells();
                else
                    numberGridBuilder.FillCells();
            }

        }

        private void CheckBoxHintOnOff_OnUnchecked(object sender, RoutedEventArgs e)
        {
            DisableHints();
        }

        private void DisableHints()
        {
            foreach (var numberGridBuilder in _numberGridBuilders)
            {
                numberGridBuilder.Clear();
            }
        }

        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var cell = GetCellAtGrid();
            var cellView = GetCellViewAt(cell);
            InvertColorOf(cellView);
            InverValueAt(cell);
            bool isDone = IsGameOver();
            if (isDone)
                MessageBox.Show("Congratulations! You completed the crossword!");
        }


        private Grid GetCellViewAt(Cell cell)
        {
            if (PixelGrid.Children.Count < 1) return new Grid();
            var cellView = PixelGrid.Children
                .Cast<UIElement>()
                .First(el => Grid.GetRow(el) == cell.Row && Grid.GetColumn(el) == cell.Col) as Grid;
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

        private void InverValueAt(Cell cell)
        {
            if (_pixelGridView.Progress[cell.Row, cell.Col] == HintsCalculator.FilledElementLiteral)
            {
                _pixelGridView.Progress[cell.Row, cell.Col] = HintsCalculator.EmptyElementLiteral;
            }
            else
            {
                _pixelGridView.Progress[cell.Row, cell.Col] = HintsCalculator.FilledElementLiteral;
            }
        }

        private Cell GetCellAtGrid()
        {
            var point = Mouse.GetPosition(PixelGrid);
            var row = GetRowAtGrid(point.Y);
            var col = GetColAtGrid(point.X);
            return new Cell(row, col);
        }

        private int GetRowAtGrid(double mouseY)
        {
            var row = 0;
            var accumulatedHeight = 0.0;
            foreach (var rowDefinition in PixelGrid.RowDefinitions)
            {
                accumulatedHeight += rowDefinition.ActualHeight;
                if (accumulatedHeight >= mouseY)
                    break;
                row++;
            }

            return row;
        }

        private int GetColAtGrid(double mouseX)
        {
            var col = 0;
            var accumulatedWidth = 0.0;
            foreach (var columnDefinition in PixelGrid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= mouseX)
                    break;
                col++;
            }

            return col;
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
                BuildCrossword();
        }

        private bool IsGameOver()
        {
            return _pixelGridView.GameProgress.IsDone();
        }
    }
}
