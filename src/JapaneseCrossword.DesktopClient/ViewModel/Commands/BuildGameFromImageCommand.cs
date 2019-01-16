using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Input;
using ImageProcessing;
using JapaneseCrossword.Core.Rules;
using Microsoft.Win32;

namespace JapaneseCrossword.DesktopClient.ViewModel.Commands
{
    internal class BuildGameFromImageCommand:BaseCommand, ICommand
    {
        private readonly GameViewModel _viewModel;
        public BuildGameFromImageCommand(GameModel model, GameViewModel viewModel) : base(model)
        {
            _viewModel = viewModel;
        }

        public async void Execute(object parameter)
        {
            var image = GetImageFromDialog();
            if (image == null)
            {
                return;
            }

            var sizeConfig = model.ParseGridSize();
            var imageGridBuilder = new ImageGridBuilder(sizeConfig.Item1, sizeConfig.Item2, image);

            var processImage = Task.Run(() => imageGridBuilder.GroupSectorsByColor());
            var colorSectors = await processImage;
            var gridData = await ConvertColorRegionsIntoGridData(colorSectors, imageGridBuilder);
            _viewModel.BuildGame(gridData);
        }

        private async Task<MonochromeCell[,]> ConvertColorRegionsIntoGridData(ColorRegion[,] regions, ImageGridBuilder builder)
        {
            RegionProcessor regionProcessor = null;
            var initProcessorTask = Task.Run(() =>
                regionProcessor = new RegionProcessor(builder.ColorStats));
            await initProcessorTask;

            MonochromeCell[,] gridData = null;
            var buildCellsTask = Task.Run(() =>
                gridData = regionProcessor.BuildMonochromeCells(regions));
            await buildCellsTask;

            return gridData;
        }

        private Bitmap GetImageFromDialog()
        {
            var fileDialog = new OpenFileDialog
            {
                DefaultExt = ".png",
                Filter =
                    "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"
            };
            var result = fileDialog.ShowDialog();
            if (result != true)
            {
                return null;
            }

            var filename = fileDialog.FileName;
            return new Bitmap(filename);
        }
    }
}
