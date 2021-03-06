﻿using System.Linq;
using JapaneseCrossword.Core.State;

namespace JapaneseCrossword.Core.Rules
{
    public class StrictRules : IRules
    {
        public bool IsComplete(GameProgress progress)
        {
            return progress.Current.Cast<MonochromeCell>().SequenceEqual(progress.Goal.Cast<MonochromeCell>());
        }
    }
}