using System.Drawing;

namespace GridGenerator
{
    public class ImageGridBuilder
    {
        private readonly int sectorWidth;
        private readonly int sectorHeight;
        private readonly Bitmap image;

        public ImageStats ColorStats { get; }

        public ImageGridBuilder(int sectorWidth, int sectorHeight, Bitmap image)
        {
            this.sectorWidth = sectorWidth;
            this.sectorHeight = sectorHeight;
            this.image = image;
            ColorStats = new ImageStats(image.Width*image.Height);
        }

        public ColorRegion[,] GroupSectorsByColor()
        {
            var secYCount = image.Width / sectorHeight;
            var secXCount = image.Height / sectorWidth;

            // To be merged with last one
            var lastSectorWidth = image.Width % sectorWidth;
            var lastSectorHeight = image.Height % sectorHeight;

            var colors = new ColorRegion[secYCount, secXCount];

            var sectors = GetColorSectors();
            
            for (var row = 0; row < secYCount; row++)
            {
                for (var col = 0; col < secXCount; col++)
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
            var sectors = new Color[sectorHeight, sectorWidth][,];
            var secYCount = image.Width / sectorHeight;
            var secXCount = image.Height / sectorWidth;
            for (var row = 0; row < secYCount; row++)
            {
                for (var col = 0; col < secXCount; col++)
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
            var sector = new Color[sectorWidth, sectorHeight];
            var startY = row * sectorHeight;
            var startX = col * sectorWidth;
            var endY = (row + 1) * sectorHeight;
            var endX = (col + 1) * sectorWidth;

            for (var secY = startY; secY < endY; secY++)
            {
                for (var secX = startX; secX < endX; secX++)
                {
                    var y = secY - startY;
                    var x = secX - startX;
                    sector[y, x] = image.GetPixel(secY, secX);
                    ColorStats.Add(sector[y,x]);
                }
            }

            return sector;
        }

    }
}
