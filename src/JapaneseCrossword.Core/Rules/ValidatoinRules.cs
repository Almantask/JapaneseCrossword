using System;
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
            
        }

        private bool IsHorizontalyCopmlete(GameProgress progress)
        {

        }

        private bool IsVerticallyComplete(GameProgress progress)
        {
            for (var col = 0; col < progress.Current.GetLength(0); col++)
            {
                for (var row = 0; row < progress.Current.GetLength(0); row++)
                {

                }
            }
        }

    }
}