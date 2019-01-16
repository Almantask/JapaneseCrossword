using System.Windows.Input;

namespace JapaneseCrossword.DesktopClient.ViewModel.Commands
{
    internal class CrosswordRevealedCommand:BaseCommand, ICommand
    {
        public CrosswordRevealedCommand(GameModel model) : base(model)
        {
        }

        public void Execute(object parameter)
        {
            if ((bool) parameter)
            {
                model.Crossword.Reveal();
            }
            else
            {
                model.Crossword.BackToProgress();
            }
        }
    }
}
