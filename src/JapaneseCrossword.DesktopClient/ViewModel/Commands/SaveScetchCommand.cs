using System.Windows;
using System.Windows.Input;
using JapaneseCrossword.Core.State;
using Microsoft.Win32;

namespace JapaneseCrossword.DesktopClient.ViewModel.Commands
{
    internal class SaveScetchCommand:BaseCommand, ICommand
    {
        public SaveScetchCommand(GameModel model) : base(model)
        {
        }

        public void Execute(object parameter)
        {
            if (model.Crossword == null)
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
                model.Crossword.SaveCustom(openFileDialog.FileName);
            }
        }
    }
}
