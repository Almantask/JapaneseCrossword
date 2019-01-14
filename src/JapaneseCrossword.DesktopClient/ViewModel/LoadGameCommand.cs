using System.Windows.Input;
using Microsoft.Win32;

namespace JapaneseCrossword.DesktopClient.ViewModel
{
    internal class LoadGameCommand:BaseCommand, ICommand
    {
        public LoadGameCommand(GameModel model) : base(model)
        {
        }

        public void Execute(object parameter)
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "Game save file type | *.jcsj",
                Title = "Select a save file"
            };
            if (openFileDialog.ShowDialog() != true)
            {
                return;
            }

            model.Crossword.Load(openFileDialog.FileName);
        }
    }
}