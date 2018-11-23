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
        // TODO: to be continued
        public int[,] ConvertToGrid(Bitmap image)
        {
            var pixels = ConvertToPixelArray(image);
            return pixels;
        }

        public int[,] ConvertToPixelArray(Bitmap image)
        {
            var pixels = new int[image.Height, image.Width];
            for (var row = 0; row < image.Height; row++)
            {
                for (var col = 0; col < image.Width; col++)
                {
                    // store pixel
                }
            }

            return pixels;
        }

        private class Pixel
        {
            public int Row { set; get; }
            public int Col { set; get; }
            public Color Color { set; get; }
            public Pixel(int row, int col, Color color)
            {
                Row = row;
                Col = col;
                Color = color;
            }
        }
    }
}