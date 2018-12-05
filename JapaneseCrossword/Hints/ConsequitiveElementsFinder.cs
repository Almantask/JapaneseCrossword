using System.Collections.Generic;
using JapaneseCrossword.Rules;

namespace JapaneseCrossword.Hints
{
    public class ConsequitiveElementsFinder:IConsequitiveElementsCountFinder
    {
        public List<int> Find(MonochromeCell[] elements)
        {
            var ConsecuitiveElementsCounts = new List<int>();
            var count = 0;
            for (var index = 0; index < elements.Length; index++)
            {
                if (elements[index].IsFilled)
                {
                    if (count == 0)
                    {
                        count++;
                    }
                    else if (elements[index].IsFilled == elements[index - 1].IsFilled)
                    {
                        count++;
                    }
                }
                else if (count != 0)
                {
                    ConsecuitiveElementsCounts.Add(count);
                    count = 0;
                }
            }

            if (count > 0)
                ConsecuitiveElementsCounts.Add(count);

            return ConsecuitiveElementsCounts;
        }

    }
}
