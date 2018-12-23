using ImageProcessing;
using JapaneseCrossword.Core;
using JapaneseCrossword.Core.Rules;
using JapaneseCrossword.Core.State;
using JapaneseCrossword.DesktopClient.DisplayableGrid;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Brushes = System.Windows.Media.Brushes;

namespace JapaneseCrossword.DesktopClient.Views
{
    public partial class MainWindow : Window
    {
        private readonly MonochromeGridView _pixelGridView;
        private List<IHintsGridBuider> _numberGridBuilders;
        private Crossword _crossword;

        public MainWindow()
        {
            InitializeComponent();
            _pixelGridView = new MonochromeGridView(PixelGrid);
            BuilHintGrids();
        }

        private void BuilHintGrids()
        {
            _numberGridBuilders = new List<IHintsGridBuider>();
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

        private void OnButtonRnadomGrid(object sender, RoutedEventArgs e)
        {
            RandomGame();
        }

        private void RandomGame()
        {
            var gridSize = ParseGridSize();
            if (gridSize == null)
            {
                return;
            }

            var dataGenerator = new GridDataGenerator();
            var cols = gridSize.Item1;
            var rows = gridSize.Item2;
            var gridData = dataGenerator.Generate(cols, rows);
            BuildGame(gridData);
        }

        private void BuildGame(MonochromeCell[,] gridData)
        {
            _crossword = new Crossword(gridData, new StrictRules(), new LocalStateLoader(),
                _pixelGridView, _numberGridBuilders);
            _crossword.Initialise(gridData);
        }

        private Tuple<int, int> ParseGridSize()
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
            }
            return gridSize;
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

        private void OnButtonImageGridClick(object sender, RoutedEventArgs e)
        {
            var image = GetImageFromDialog();
            if (image == null)
            {
                return;
            }

            var sizeConfig = ParseGridSize();
            var imageGridBuilder = new ImageGridBuilder(sizeConfig.Item1, sizeConfig.Item2, image);
            var colorSectors = imageGridBuilder.GroupSectorsByColor();
            var regionProcessor = new RegionProcessor(imageGridBuilder.ColorStats);
            var gridData = regionProcessor.BuildMonochromeCells(colorSectors);
            BuildGame(gridData);
        }

        private Bitmap GetImageFromDialog()
        {
            var fileDialog = new OpenFileDialog
            {
                DefaultExt = ".png",
                Filter =
                    "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"
            };
            var result = fileDialog.ShowDialog();
            if (result != true)
            {
                return null;
            }

            var filename = fileDialog.FileName;
            return new Bitmap(filename);
        }

        private void CheckBoxRevealed_OnChecked(object sender, RoutedEventArgs e)
        {
            _crossword?.Reveal();
        }

        private void CheckBoxRevealed_OnUnchecked(object sender, RoutedEventArgs e)
        {
            _crossword?.BackToProgress();
        }


        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (_crossword == null)
            {
                return;
            }

            var cell = GetCellAtGrid();
            var cellView = GetCellViewAt(cell.Item1, cell.Item2);
            InvertColorOf(cellView);
            _crossword.InvertCell(cell.Item1, cell.Item2);
            var isDone = _crossword.IsGameOver();
            if (isDone)
            {
                MessageBox.Show("Congratulations! You completed the crossword!");
            }
        }


        private Grid GetCellViewAt(int row, int col)
        {
            if (PixelGrid.Children.Count < 1)
            {
                return new Grid();
            }

            var cellView = PixelGrid.Children
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
            var point = Mouse.GetPosition(PixelGrid);
            var row = GetRowAtGrid(point.Y);
            var col = GetColAtGrid(point.X);
            return new Tuple<int, int>(row, col);
        }

        private int GetRowAtGrid(double mouseY)
        {
            var row = 0;
            var accumulatedHeight = 0.0;
            foreach (var rowDefinition in PixelGrid.RowDefinitions)
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
            foreach (var columnDefinition in PixelGrid.ColumnDefinitions)
            {
                accumulatedWidth += columnDefinition.ActualWidth;
                if (accumulatedWidth >= mouseX)
                {
                    break;
                }

                col++;
            }

            return col;
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RandomGame();
            }
        }

        private void LoadProgress_OnClick(object sender, RoutedEventArgs e)
        {
            var loader = new LocalStateLoader();
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Game save file type | *.jcsj",
                Title = "Select a save file"
            };
            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }

            _crossword.Load(openFileDialog.FileName);
        }

        private void SaveProgress_OnClick(object sender, RoutedEventArgs e)
        {
            if (_crossword == null)
            {
                MessageBox.Show("No grid to be saved");
                return;
            }
            var loader = new LocalStateLoader();
            var openFileDialog = new SaveFileDialog
            {
                Filter = "Game save file type | *.jcsj",
                Title = "Save game progress to a file"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                _crossword.Save(openFileDialog.FileName);
            }
        }

        private void SaveCustom_OnClick(object sender, RoutedEventArgs e)
        {
            if (_crossword == null)
            {
                MessageBox.Show("No grid to be saved");
                return;
            }
            var loader = new LocalStateLoader();
            var openFileDialog = new SaveFileDialog
            {
                Filter = "Game save file type | *.jcsj",
                Title = "Save game progress to a file"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                _crossword.SaveCustom(openFileDialog.FileName);
            }
        }
    }
}
