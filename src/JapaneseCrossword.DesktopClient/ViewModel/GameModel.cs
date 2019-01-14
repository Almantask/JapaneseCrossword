using System;
using System.ComponentModel;
using System.Windows;
using JapaneseCrossword.Core;

namespace JapaneseCrossword.DesktopClient.ViewModel
{
    internal class GameModel:INotifyPropertyChanged
    {
        public Crossword Crossword { set; get; }

        private string _gridSize;
        public string GridSize
        {
            get => _gridSize;
            set
            {
                _gridSize = value;
                OnPropertyChanged("GridSize");
            }
        }

        private bool _isRevealed;
        public bool IsRevealed
        {
            get => _isRevealed;
            set
            {
                _isRevealed = value;
                OnPropertyChanged("IsRevealed");
            }
        }

        public Tuple<int, int> ParseGridSize()
        {
            Tuple<int, int> gridSize = null;
            try
            {
                gridSize = ParseGridSize(GridSize);
            }
            catch
            {
                MessageBox.Show($"Failed to read grid size: {GridSize} is not valid");
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
