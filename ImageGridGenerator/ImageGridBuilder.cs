using System.Drawing;

namespace GridGenerator
{
    public class ImageGridBuilder   
    {
        // There are quite many problems here:
        // fundamentally the pixel is supposed to be changed
        // into multiple regions of pixels.
        public ColorRegion[,] GroupSectorsByColor(Bitmap image, int sectorWidth, int sectorHeight)
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
                    var color = AverageColor(sector);
                    var colorRegion = new ColorRegion(sectorHeight, sectorWidth, color);
                    colors[row, col] = colorRegion;
                }
            }

            return colors;
        }

        private Color AverageColor(Color[,] sector)
        {
            var r = 0;
            var g = 0;
            var b = 0;
            var rows = sector.GetLength(0);
            var cols = sector.GetLength(1);
            var total = rows * cols;

            foreach (var color in sector)
            {
                r += color.R * color.A;
                g += color.G * color.A;
                b = color.B * color.A;
            }

            r /= total;
            g /= total;
            b /= total;
            var avgColor = Color.FromArgb(255, r, g, b);
            return avgColor;
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

        private Color[,][,] GetColorSectors(Bitmap image)
        {
            int sectorWidth = 5;
            int sectorHeight = 5;
            var sectors = new Color[sectorHeight, sectorWidth][,];
            var pixels = new int[image.Height, image.Width];
            var secX = 0;
            var secY = 0;
            var secYCount = image.Width / sectorHeight;
            var secXCount = image.Height / sectorWidth;
            for (var row = secY; row < secYCount; row++)
            {
                for (var col = secX; col < secXCount; col++)
                {
                    var color = image.GetPixel(row, col);
                    var sector = GetSector(row, col, sectorWidth, sectorHeight, image);
                    sectors[row, col] = sector;
                }
            }
            return sectors;
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

        public class ColorRegion
        {
            public int Height { get; }
            public int Width { get; }
            public bool IsBalck { get; }
            public Color Color { get; }
            public ColorRegion(int row, int col, Color color)
            {
                Height = row;
                Width = col;
                Color = color;
            }
        }
    }
}
