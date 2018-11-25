using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGenerator
{
    public class ImageGridder
    {
        // There are quite many problems here:
        // fundamentally the pixel is supposed to be changed
        // into multiple regions of pixels.
        public ColorRegion[,] ConvertToGrid(Bitmap image)
        {
            var sectors = GetColorSectors(image);
            var colorRegions = new ColorRegion[5,5];
            for (var row = 0; row < 5; row++)
            {
                for (var col = 0; col < 5; col++)
                {
                    colorRegions[row,col] = new ColorRegion(5, 5, sectors[row, col]);
                }
            }
            return colorRegions;
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
            var sectors = new Color[5,5][,];
            var pixels = new int[image.Height, image.Width];
            for (var row = 0; row < image.Height; row++)
            {
                for (var col = 0; col < image.Width; col++)
                {
                    var color = image.GetPixel(row, col);
                   // TODO: continue
                }
            }
            return sectors;
        }

        public class ColorRegion
        {
            public int Height { get; }
            public int Width { get; }
            public bool IsBalck { get; }
            public ColorRegion(int row, int col, Color[,] colors)
            {
                Height = row;
                Width = col;
                IsBalck = IsRegionWhite(colors);
            }

            private bool IsRegionWhite(Color[,] region)
            {
                return true;
            }
        }
    }
}