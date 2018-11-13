using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using ImageGridGenerator;
using JapaneseCrossWord.DisplayableGrid;

namespace JapaneseCrossWord.Views
{
    public partial class MainWindow : Window
    {
        private readonly MonochromeGridBuilder _gridBuilder;
        private int _preferableGridSize = 9;
        private List<NumberGridBuilder> _numberGridBuilders;
        private bool _isFirstLoad = true;

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

            var hintsCalculator = new HintsCalculator(_gridBuilder.GridData);
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
            try
            {
                var gridSize = ParseGridSize(gridSizeInput);
                BuildMainGrid(gridSize.Item1, gridSize.Item2);
                BuildHintGrids(gridSize.Item1, gridSize.Item2);
            }
            catch
            {
                MessageBox.Show($"Failed to read grid size: {gridSizeInput} is not valid");
            }
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
            _gridBuilder.BuildGrid(cols, rows);
        }

        private void BuildHintGrids(int cols, int rows)
        {
            foreach (var hintGridBuilder in _numberGridBuilders)
            {
                if (hintGridBuilder.IsVertical)
                    hintGridBuilder.BuildGrid(3, rows);
                else
                    hintGridBuilder.BuildGrid(cols, 3);
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
            var gridSizeInput = textBoxGridSize.Text;
            try
            {
                var gridSize = ParseGridSize(gridSizeInput);
                foreach (var numberGridBuilder in _numberGridBuilders)
                {
                    if (numberGridBuilder.IsVertical)
                        numberGridBuilder.FillCells();
                    else
                        numberGridBuilder.FillCells();
                }
            }
            catch
            {
                MessageBox.Show($"Failed to read grid size: {gridSizeInput} is not valid");
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
