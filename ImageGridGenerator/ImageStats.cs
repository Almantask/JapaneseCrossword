using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GridGenerator
{
    public class ImageStats
    {
        private SortedList<short, Color> pixels;

        public short MedianValue
        {
            get
            {
                if (!pixels.Any())
                    throw new StatsNotSetException("No pixels");
                return pixels.Keys[pixels.Count / 2];
            }
        }

        public Color MedianColor
        {
            get
            {
                if (!pixels.Any())
                    throw new StatsNotSetException("No pixels");
                return pixels.Values[pixels.Count / 2];
            }
        }

        public ImageStats(int pixelsCount)
        {
            pixels = new SortedList<short, Color>(pixelsCount);
        }

        public int CalculateAverageValue()
        {
            var avg = 0;
            foreach (var value in pixels.Keys)
            {
                avg += value;
            }

            return avg / pixels.Count;
        }

        public Color CalculateAverageColor()
        {
            var r = 0;
            var g = 0;
            var b = 0;
            var a = 0;
            foreach (var color in pixels.Values)
            {
                r += color.R;
                g += color.G;
                b += color.B;
                a += color.A;
            }

            return Color.FromArgb(a / pixels.Count, 
                r / pixels.Count, g / pixels.Count, b / pixels.Count);
        }

        public void Add(Color color)
        {
            var sum = (short)(color.A / 255.0 * (color.G + color.B + color.R));
            pixels.Add(sum, color);
        }

    }
}