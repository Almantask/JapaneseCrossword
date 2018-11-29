using System.Collections.Generic;
using General;
using JapaneseCrossword.Rules;
using JapaneseCrossword.State;

namespace JapaneseCrossword.Hints
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
                var rowElements = GetRowElements(row);
                var counts = ConsequitiveElementsFinder.Find(rowElements);
                hintsPerRow[row] = counts;
            }

            return hintsPerRow;
        }

        private MonochromeCell[] GetRowElements(int row)
        {
            var rowElements = new MonochromeCell[CellData.GetLength(1)];
            for (var col = 0; col < CellData.GetLength(1); col++)
            {
                rowElements[col] = CellData[row, col];
            }

            return rowElements;
        }
    }
}
