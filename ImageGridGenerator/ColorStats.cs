using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GridGenerator
{
    public static class ColorStats
    {
        public static short GetValue(Color color)
        {
            return (short)(color.A / 255.0 * (color.G + color.B + color.R));
        }
    }
}
