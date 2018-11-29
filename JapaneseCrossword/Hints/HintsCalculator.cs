using JapaneseCrossword.Rules;
using JapaneseCrossword.State;

namespace JapaneseCrossword.Hints
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
