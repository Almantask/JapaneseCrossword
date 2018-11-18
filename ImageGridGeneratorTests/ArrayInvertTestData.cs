using System.Collections;
using System.Collections.Generic;

namespace ImageGridGeneratorTests
{
    internal class ArrayInvertTestData : IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Input1, ExpectedOutput1 };
            yield return new object[] { Input2, ExpectedOutput2 };
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

        private int[,] ExpectedOutput1 => new[,]
        {
            {1, 1, 1, 1, 0 },
            {1, 0, 1, 1, 0 },
            {0, 1, 1, 1, 0 },
            {0, 0, 0, 1, 0 }
        };

        private int[,] Input2 => new[,]
        {
            {1, 1, 1, 1 },
            {1, 1, 1, 1 },
            {1, 1, 1, 1 },
            {1, 1, 1, 1 },
            {1, 1, 1, 1 }
        };

        private int[,] ExpectedOutput2 => new[,]
        {
            {1, 1, 1, 1, 1 },
            {1, 1, 1, 1, 1 },
            {1, 1, 1, 1, 1 },
            {1, 1, 1, 1, 1 }
        };

        private int[,] Input4 => new[,]
        {
            {1, 0, 0, 0 },
            {0, 1, 0, 0 },
            {0, 0, 1, 0 },
            {0, 0, 0, 1 },
        };

        private int[,] ExpectedOutput4 => new[,]
        {
            {1, 0, 0, 0 },
            {0, 1, 0, 0 },
            {0, 0, 1, 0 },
            {0, 0, 0, 1 }
        };

        private int[,] Input5 => new[,]
        {
            {1, 0, 0, 0 },
            {1, 1, 0, 0 },
            {1, 1, 1, 0 },
            {1, 1, 1, 1 },
        };

        private int[,] ExpectedOutput5 => new[,]
        {
            {1, 1, 1, 1 },
            {0, 1, 1, 1 },
            {0, 0, 1, 1 },
            {0, 0, 0, 1 },
        };

        private int[,] Input6 => new[,]
        {
            {1, 1, 0, 1 }
        };

        private int[,] ExpectedOutput6 => new[,]
        {
            {1 },
            {1 },
            {0 },
            {1 },
        };

        private int[,] Input7 => new[,]
        {
            {0, 0, 0, 0 }
        };

        private int[,] ExpectedOutput7 => new[,]
        {
            {0 },
            {0 },
            {0 },
            {0 },
        };

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}