using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace GridGenerator
{
    public class ImageStats
    {
        private readonly List<Color> _pixels;

        public ImageStats(int pixelsCount)
        {
            _pixels = new List<Color>(pixelsCount);
        }

        public float CalculateAverageValue()
        {
            float avg = 0;
            foreach (var color in _pixels)
            {
                avg += ColorStats.GetValue(color);
            }

            return avg / _pixels.Count;
        }

        public Color CalculateAverageColor()
        {
            return CalculateAverageColor(_pixels);
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
            _pixels.Add(color);
        }

    }
}