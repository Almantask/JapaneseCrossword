using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JapaneseCrossword.Rules;

namespace GridGenerator
{
    public class RegionProcessor
    {
        private readonly int _averageImageColorValue;

        public RegionProcessor(ImageStats stats)
        {
            _averageImageColorValue = stats.CalculateAverageValue();
        }

        public MonochromeCell[,] BuildMonochromeCells(ColorRegion[,] regions)
        {
            var cols = regions.GetLength(1);
            var rows = regions.GetLength(0);

            var cells = new MonochromeCell[rows, cols];

            for(var row = 0; row < rows; row++)
            {
                for (var col = 0; col < cols; col++)
                {
                    cells[row, col] = BuildMonochrome(regions[row, col]);
                }
            }

            return cells;
        }

        public MonochromeCell BuildMonochrome(ColorRegion region)
        {
            if (_averageImageColorValue > ColorStats.GetValue(region.Color))
            {
                return new MonochromeCell(true);
            }
            else
            {
                return new MonochromeCell(false);
            }
        }
    }
}
