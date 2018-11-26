using System.Collections.Generic;
using JapaneseCrossword.Rules;
using JapaneseCrossword.State;

namespace JapaneseCrossword.Hints
{
    public interface IConsequitiveElementsCountFinder
    {
        List<int> Find(MonochromeCell[] elements);
    }
}
