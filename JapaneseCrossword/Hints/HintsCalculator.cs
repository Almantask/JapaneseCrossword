using JapaneseCrossword.Rules;
using JapaneseCrossword.State;

namespace JapaneseCrossword.Hints
{
    public class HintsCalculator
    {
        protected MonochromeCell[,] CellData { get; }
        protected IConsequitiveElementsCountFinder ConsequitiveElementsFinder { get; }

        public HintsCalculator(MonochromeCell[,] cellData, IConsequitiveElementsCountFinder consequitiveElementsCountFinder)
        {
            CellData = cellData;
            ConsequitiveElementsFinder = consequitiveElementsCountFinder;
        }
    }
}
