using System.Drawing;

namespace GridGenerator
{
    public class ImageGridBuilder
    {
        private readonly int sectorRows;
        private readonly int sectorCols;
        private readonly Bitmap image;
        private readonly int sectorWidth;
        private readonly int sectorHeight;

        public ImageStats ColorStats { get; }

        public ImageGridBuilder(int sectorRows, int sectorCols, Bitmap image)
        {
            this.sectorRows = sectorRows;
            this.sectorCols = sectorCols;
            this.image = image;
            ColorStats = new ImageStats(image.Width*image.Height);
            sectorWidth = image.Width / sectorCols;
            sectorHeight = image.Height / sectorRows;
        }

        public ColorRegion[,] GroupSectorsByColor()
        {

            // To be merged with last one
            var lastSectorWidth = image.Width % sectorWidth;
            var lastSectorHeight = image.Height % sectorHeight;

            var colors = new ColorRegion[sectorRows, sectorCols];

            var sectors = GetColorSectors();
            
            for (var row = 0; row < sectorRows; row++)
            {
                for (var col = 0; col < sectorCols; col++)
                {
                    var sector = sectors[row, col];
                    var color = ColorStats.CalculateAverageColorArr(sector);
                    var colorRegion = new ColorRegion(sectorHeight, sectorWidth, color);
                    colors[row, col] = colorRegion;
                }
            }

            return colors;
        }

        private Color[,][,] GetColorSectors()
        {
            var sectors = new Color[sectorRows, sectorCols][,];
            for (var row = 0; row < sectorRows; row++)
            {
                for (var col = 0; col < sectorCols; col++)
                {
                    var sector = GetSector(row, col);
                    sectors[row, col] = sector;
                }
            }
            return sectors;
        }

        //TODO: what to do with an offset?
        private int CalculateColorRegionWidth(int totalWidth, int regionWidth)
        {
            return totalWidth / regionWidth;
        }

        private int CalculateColorRegionHeight(int totalHeight, int regionHeight)
        {
            return totalHeight / regionHeight;
        }

        private Color[,] GetSector(int row, int col)
        {
            var sector = new Color[sectorHeight, sectorWidth];
            var startY = row * sectorHeight;
            var startX = col * sectorWidth;
            var endY = (row + 1) * sectorHeight;
            var endX = (col + 1) * sectorWidth;

            // TODO: double check last index
            for (var secY = startY; secY < endY-1; secY++)
            {
                for (var secX = startX; secX < endX-1; secX++)
                {
                    var y = secY - startY;
                    var x = secX - startX;
                    sector[y, x] = image.GetPixel(secX, secY);
                    ColorStats.Add(sector[y,x]);
                }
            }

            return sector;
        }

    }
}
