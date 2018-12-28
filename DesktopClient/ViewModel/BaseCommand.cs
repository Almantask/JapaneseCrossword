using System;

namespace JapaneseCrossword.DesktopClient.ViewModel
{
    internal class BaseCommand
    {
        protected GameModel model { set; get; }

        public BaseCommand(GameModel model)
        {
            this.model = model;
        }

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }
}
