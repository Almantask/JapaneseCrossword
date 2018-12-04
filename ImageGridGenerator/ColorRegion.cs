using System.Drawing;

namespace GridGenerator
{
    public class ColorRegion
    {
        public int Height { get; }
        public int Width { get; }
        public Color Color { get; }

        public ColorRegion(int row, int col, Color color)
        {
            Height = row;
            Width = col;
            Color = color;
        }

        
    }
}