using System.Drawing;

namespace GridGenerator
{
    public class ImageGridBuilder
    {
        private int sectorWidth;
        private int sectorHeight;
        private Bitmap image;

        public ImageStats ColorStats { private set; get; }

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

            var sectors = GetColorSectors(image);
            
            for (var row = 0; row < secYCount; row++)
            {
                for (var col = 0; col < secXCount; col++)
                {
                    var sector = sectors[row, col];
                    var color = ColorStats.CalculateAverageColor();
                    var colorRegion = new ColorRegion(sectorHeight, sectorWidth, color);
                    colors[row, col] = colorRegion;
                }
            }

            return colors;
        }

        private Color[,][,] GetColorSectors(Bitmap image)
        {
            var sectors = new Color[sectorHeight, sectorWidth][,];
            var secYCount = image.Width / sectorHeight;
            var secXCount = image.Height / sectorWidth;
            for (var row = 0; row < secYCount; row++)
            {
                for (var col = 0; col < secXCount; col++)
                {
                    var color = image.GetPixel(row, col);
                    var sector = GetSector(row, col, sectorWidth, sectorHeight, image);
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

        private Color[,] GetSector(int row, int col, int height, int width, Bitmap image)
        {
            var sector = new Color[width, height];
            var startY = row * height;
            var startX = col * width;
            var endY = (row + 1) * height;
            var endX = (col + 1) * width;

            for (var secY = startY; secY < endY; secY++)
            {
                for (var secX = startX; secX < endX; secX++)
                {
                    var y = secY - startY;
                    var x = secX - startX;
                    sector[y, x] = image.GetPixel(secY, secX);
                }
            }

            return sector;
        }

    }
}
