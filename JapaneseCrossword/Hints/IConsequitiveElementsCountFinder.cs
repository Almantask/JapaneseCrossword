using System.Collections.Generic;
using JapaneseCrossword.Rules;

namespace JapaneseCrossword.Hints
{
    public interface IConsequitiveElementsCountFinder
    {
        List<int> Find(MonochromeCell[] elements);
    }
}
