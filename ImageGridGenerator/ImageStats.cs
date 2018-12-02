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
            return CalculateAverageColor(pixels.Values);
        }

        public Color CalculateAverageColorArr(Color[,] colors)
        {
            return CalculateAverageColor(colors.Cast<Color>());
        }

        public static Color CalculateAverageColor(IEnumerable<Color> colors)
        {
            var r = 0;
            var g = 0;
            var b = 0;
            var a = 0;

            int count = 0;
            foreach (var color in colors)
            {
                r += color.R;
                g += color.G;
                b += color.B;
                a += color.A;
                count++;
            }

            return Color.FromArgb(a / count, r / count, g / count, b / count);
        }

        public void Add(Color color)
        {
            var sum = (short)(color.A / 255.0 * (color.G + color.B + color.R));
            pixels.Add(sum, color);
        }

    }
}