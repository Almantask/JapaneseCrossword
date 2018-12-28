using System.Windows;
using JapaneseCrossword.DesktopClient.ViewModel;

namespace JapaneseCrossword.DesktopClient.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new GameViewModel(PixelGrid, LeftHintGrid, RightHintGrid, TopHintGrid, BottomHintGrid);
        }
    }
}
