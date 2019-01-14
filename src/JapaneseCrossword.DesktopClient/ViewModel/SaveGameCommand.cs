using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;

namespace JapaneseCrossword.DesktopClient.ViewModel
{
    internal class SaveGameCommand:BaseCommand, ICommand
    {
        public SaveGameCommand(GameModel model) : base(model)
        {
        }

        public void Execute(object parameter)
        {
            if (model.Crossword == null)
            {
                MessageBox.Show("No grid to be saved");
                return;
            }
            var openFileDialog = new SaveFileDialog
            {
                Filter = "Game save file type | *.jcsj",
                Title = "Save game progress to a file"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                model.Crossword.Save(openFileDialog.FileName);
            }
        }
    }
}
