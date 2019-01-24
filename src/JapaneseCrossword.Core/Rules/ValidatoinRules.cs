using System.Collections.Generic;
using System.Linq;
using JapaneseCrossword.Core.Extensions;
using JapaneseCrossword.Core.Hints;
using JapaneseCrossword.Core.State;

namespace JapaneseCrossword.Core.Rules
{
    public class ValidatoinRules: IRules
    {
        private int[,] _horizontalHints;
        private int[,] _verticalHints;
        private IConsequitiveElementsCountFinder _consequitiveElementsFinder;

        public ValidatoinRules(IConsequitiveElementsCountFinder consequitiveElementsFinder, int[,] horizontalHints, int[,] verticalHints)
        {
            _horizontalHints = horizontalHints;
            _verticalHints = verticalHints;
            _consequitiveElementsFinder = consequitiveElementsFinder;
        }

        public bool IsComplete(GameProgress progress)
        {
            return IsHorizontalyComplete(progress) &&
                   IsVerticallyComplete(progress);
        }

        private bool IsHorizontalyComplete(GameProgress progress)
        {
            var rows = progress.Current.GetLength(1);
            var horizontalyConsequitive = new List<int>[rows];

            for (var row = 0; row < rows; row++)
            {
                var rowElements = progress.Current.GetRowElements(row);
                var consequitiveElements = _consequitiveElementsFinder.Find(rowElements);
                horizontalyConsequitive[row] = consequitiveElements;
            }

            return horizontalyConsequitive.Cast<int>().SequenceEqual(_horizontalHints.Cast<int>());
        }

        private bool IsVerticallyComplete(GameProgress progress)
        {
            var cols = progress.Current.GetLength(0);
            var horizontalyConsequitive = new List<int>[cols];

            for (var col = 0; col < cols; col++)
            {
                var rowElements = progress.Current.GetRowElements(col);
                var consequitiveElements = _consequitiveElementsFinder.Find(rowElements);
                horizontalyConsequitive[col] = consequitiveElements;
            }

            return horizontalyConsequitive.Cast<int>().SequenceEqual(_horizontalHints.Cast<int>());
        }

    }
}