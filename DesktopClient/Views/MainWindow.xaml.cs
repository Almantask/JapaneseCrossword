using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace JapaneseCrossWord
{
    public partial class MainWindow : Window
    {
        private MonochromeGridBuilder _monochromeGridBuilder;

        private int _preferableGridSize = 9;

        public MainWindow()
        {
            InitializeComponent();
            _monochromeGridBuilder = new MonochromeGridBuilder(PixelGrid);
        }

        
        // TODO: MVVM
        private void OnButtonRnadomGrid(object sender, RoutedEventArgs e)
        {
            var gridSizeInput = textBoxGridSize.Text;
            try
            {
                var gridSize = ParseGridSize(gridSizeInput);
                _monochromeGridBuilder.BuildGrid(gridSize.Item1, gridSize.Item2);
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

        private void OnButtonImageGridClick(object sender, RoutedEventArgs e)
        {
            BitmapImage image = GetImageFromDialog();
            if (image == null) return;

            _monochromeGridBuilder.BuildGrid(_preferableGridSize);
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
    }
}
