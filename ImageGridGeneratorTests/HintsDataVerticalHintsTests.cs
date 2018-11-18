using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ImageGridGeneratorTests
{
    internal class HintsCalculatorVerticalHintsTestData : IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Input1, ExpectedOutput1 };
            yield return new object[] { Input2, ExpectedOutput2 };
            yield return new object[] { Input3, ExpectedOutput3 };
            yield return new object[] { Input4, ExpectedOutput4 };
            yield return new object[] { Input5, ExpectedOutput5 };
            yield return new object[] { Input6, ExpectedOutput6 };
            yield return new object[] { Input7, ExpectedOutput7 };
        }

        private int[,] Input1 => new[,]
        {
            {1, 1, 0, 0 },
            {1, 0, 1, 0 },
            {1, 1, 1, 0 },
            {1, 1, 1, 1 },
            {0, 0, 0, 0 }
        };

        private List<int>[] ExpectedOutput1 => new[]
        {
            new List<int>() {4},
            new List<int>(){1,2},
            new List<int>(){3},
            new List<int>(){1},
        };

        private int[,] Input2 => new[,]
        {
            {1, 1, 1, 1 },
            {1, 1, 1, 1 },
            {1, 1, 1, 1 },
            {1, 1, 1, 1 },
            {1, 1, 1, 1 }
        };

        private List<int>[] ExpectedOutput2 => new[]
        {
            new List<int>(){5},
            new List<int>(){5},
            new List<int>(){5},
            new List<int>(){5}
        };

        private int[,] Input3 => new[,]
        {
            {0, 0, 0, 0 },
            {0, 0, 0, 0 },
            {0, 0, 0, 0 },
            {0, 0, 0, 0 },
            {0, 0, 0, 0 }
        };

        private List<int>[] ExpectedOutput3 => new[]
        {
            new List<int>(),
            new List<int>(),
            new List<int>(),
            new List<int>()
        };

        private int[,] Input4 => new[,]
        {
            {1, 0, 0, 0 },
            {0, 1, 0, 0 },
            {0, 0, 1, 0 },
            {0, 0, 0, 1 },
        };

        private List<int>[] ExpectedOutput4 => new[]
        {
            new List<int>(){1},
            new List<int>(){1},
            new List<int>(){1},
            new List<int>(){1},
        };

        private int[,] Input5 => new[,]
        {
            {1, 0, 0, 0 },
            {1, 1, 0, 0 },
            {1, 1, 1, 0 },
            {1, 1, 1, 1 },
        };

        private List<int>[] ExpectedOutput5 => new[]
        {
            new List<int>(){4},
            new List<int>(){3},
            new List<int>(){2},
            new List<int>(){1},
        };

        private int[,] Input6 => new[,]
        {
            {1, 1, 0, 1 }
        };

        private List<int>[] ExpectedOutput6 => new[]
        {
            new List<int>(){1},
            new List<int>(){1},
            new List<int>(),
            new List<int>(){1},
        };

        private int[,] Input7 => new[,]
        {
            {0, 0, 0, 0 }
        };

        private List<int>[] ExpectedOutput7 => new[]
        {
            new List<int>(),
            new List<int>(),
            new List<int>(),
            new List<int>()
        };

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
