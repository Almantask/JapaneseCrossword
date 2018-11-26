using System;
using JapaneseCrossword.State;

namespace JapaneseCrossword.Rules
{
    public class ValidatoinRules: IRules
    {
        private int[,] _horizontalHints;
        private int[,] _verticalHints;

        public ValidatoinRules(int[,] horizontalHints, int[,] verticalHints)
        {
            _horizontalHints = horizontalHints;
            _verticalHints = verticalHints;
        }

        public bool IsComplate(GameProgress progress)
        {
            throw new NotImplementedException();
        }

    }
}