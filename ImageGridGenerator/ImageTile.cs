using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ImageGridGenerator
{
    public class ImageTile
    {
        public int Column { set; get; }
        public int Row { set; get; }
        public Bitmap RawImage { get; }

        public ImageTile(int column, int row, Bitmap rawImageFull, int width, int height)
        {
            Column = column;
            Row = row;
            RawImage = BuildRawImage(rawImageFull, width, height);
        }

        private Bitmap BuildRawImage(Bitmap rawImageFull, int width, int height)
        {

            Rectangle tileBounds = new Rectangle(Column * width, Row * height, width, height);
            Bitmap tileImage = new Bitmap(width, height);

            using (Graphics graphics = Graphics.FromImage(tileImage))
            {
                graphics.DrawImage(
                    rawImageFull,
                    new Rectangle(0, 0, width, height),
                    tileBounds,
                    GraphicsUnit.Pixel);
            }

            return tileImage;
        }
    }
}
