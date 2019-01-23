using System.Collections.Generic;
using General;
using JapaneseCrossword.Core.Extensions;
using JapaneseCrossword.Core.Rules;

namespace JapaneseCrossword.Core.Hints
{
    public class HorizontalHintsCalculator:HintsCalculator
    {
        public HorizontalHintsCalculator(MonochromeCell[,] cellData, IConsequitiveElementsCountFinder consequitiveElementsCountFinder) : base(cellData, consequitiveElementsCountFinder)
        {
        }

        public override int[,] Calculate()
        {
            var hints = GetConsecuitiveHorizontalElements();
            return ComplexColectionHelpers.ListArrayToJaggedArrayHorizontal(hints);
        }

        public List<int>[] GetConsecuitiveHorizontalElements()
        {
            var hintsPerRow = new List<int>[CellData.GetLength(0)];
            for (var row = 0; row < CellData.GetLength(0); row++)
            {
                var rowElements = CellData.GetRowElements(row);
                var counts = ConsequitiveElementsFinder.Find(rowElements);
                hintsPerRow[row] = counts;
            }

            return hintsPerRow;
        }
    }
}
