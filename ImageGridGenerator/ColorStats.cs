using System.Drawing;

namespace GridGenerator
{
    public static class ColorStats
    {
        public static float GetValue(Color color)
        {
            return GrayscaleConverter.ConvertToGrayscaleV1(color);
            //return (short)(color.A / 255.0 * (color.G + color.B + color.R));
        }
    }
}
