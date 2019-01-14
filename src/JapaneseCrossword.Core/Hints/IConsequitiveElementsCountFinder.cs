using System.Collections.Generic;
using JapaneseCrossword.Core.Rules;

namespace JapaneseCrossword.Core.Hints
{
    public interface IConsequitiveElementsCountFinder
    {
        List<int> Find(MonochromeCell[] elements);
    }
}
