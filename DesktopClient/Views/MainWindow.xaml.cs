using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ImageGridGenerator;
using JapaneseCrossWord.DisplayableGrid;
using GridGenerator;

namespace JapaneseCrossWord.Views
{
    public partial class MainWindow : Window
    {
        private readonly MonochromeGridBuilder _gridBuilder;
        private int _preferableGridSize = 9;
        private List<NumberGridBuilder> _numberGridBuilders;
        private bool _isFirstLoad = true;
        GridDataGenerator _gridDataGenerator = new GridDataGenerator();

        public MainWindow()
        {
            InitializeComponent();
            _gridBuilder = new MonochromeGridBuilder(PixelGrid);
            BuilHintGrids();
        }

        private void BuilHintGrids()
        {
            _numberGridBuilders = new List<NumberGridBuilder>();
            Grid[] hintGridsSides = { LeftHintGrid, RightHintGrid };
            Grid[] hintGridsGroundRoof = { TopHintGrid, BottomHintGrid };

            foreach (var hintGrid in hintGridsSides)
            {
                var numberGridBuilder = new NumberGridBuilder(hintGrid, true);
                _numberGridBuilders.Add(numberGridBuilder);
            }
            foreach (var hintGrid in hintGridsGroundRoof)
            {
                var numberGridBuilder = new NumberGridBuilder(hintGrid, false);
                _numberGridBuilders.Add(numberGridBuilder);
            }
        }


        // TODO: MVVM
        private void OnButtonRnadomGrid(object sender, RoutedEventArgs e)
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
            var gridData = _gridDataGenerator.Generate(cols, rows, 0, 1);
            _gridBuilder.GridData = gridData;
            _gridBuilder.BuildGrid(cols, rows);
        }

        private void BuildHintGrids()
        {
            var hintsCalculator = new HintsCalculator(_gridBuilder.GridData);
            //var verticalHintsGridData = hintsCalculator.CalculateVerticalHints();
            //var horizontalHintsGridData = hintsCalculator.CalculateHorizontalHints();
            var horizontalHintsGridData = hintsCalculator.CalculateVerticalHints().InvertOrientation();
            var verticalHintsGridData = hintsCalculator.CalculateHorizontalHints().InvertOrientation();
            foreach (var hintGridBuilder in _numberGridBuilders)
            {
                if (hintGridBuilder.IsVertical)
                {
                    hintGridBuilder.GridData = verticalHintsGridData;
                    var rows = verticalHintsGridData.GetLength(0);
                    var cols = verticalHintsGridData.GetLength(1);
                    hintGridBuilder.BuildGrid(cols, rows);
                }
                else
                {
                    hintGridBuilder.GridData = horizontalHintsGridData;
                    var rows = horizontalHintsGridData.GetLength(0);
                    var cols = horizontalHintsGridData.GetLength(1);
                    hintGridBuilder.BuildGrid(cols, rows);
                }
            }
        }

        private void OnButtonImageGridClick(object sender, RoutedEventArgs e)
        {
            BitmapImage image = GetImageFromDialog();
            if (image == null) return;

            _gridBuilder.BuildGrid(_preferableGridSize);
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
    }
}
