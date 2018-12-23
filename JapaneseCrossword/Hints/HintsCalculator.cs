using JapaneseCrossword.Core.Rules;

namespace JapaneseCrossword.Core.Hints
{
    public abstract class HintsCalculator:IHintsCalculator
    {
        protected MonochromeCell[,] CellData { get; }
        protected IConsequitiveElementsCountFinder ConsequitiveElementsFinder { get; }

        protected HintsCalculator(MonochromeCell[,] cellData, IConsequitiveElementsCountFinder consequitiveElementsCountFinder)
        {
            CellData = cellData;
            ConsequitiveElementsFinder = consequitiveElementsCountFinder;
        }

        public abstract int[,] Calculate();
    }
}
