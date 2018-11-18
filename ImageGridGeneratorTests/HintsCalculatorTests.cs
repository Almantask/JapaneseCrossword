using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageGridGenerator;
using Xunit;

namespace ImageGridGeneratorTests
{
    public class HintsCalculatorTests
    {
        private HintsCalculator _hintsCalculator;

        [Theory]
        [ClassData(typeof(HintsCalculatorVerticalHintsTestData))]
        public void CalculateVerticalHintsTest(int[,] input, List<int>[] expectedOutput)
        {
            _hintsCalculator = new HintsCalculator(input);
            var hints = _hintsCalculator.GetConsecuitiveVerticalElements();
            var actual2D = ComplexColectionHelpers.ListArrayToJaggedArrayVertical(hints);
            var expected2D = ComplexColectionHelpers.ListArrayToJaggedArrayVertical(expectedOutput);
            var actual = actual2D.Cast<int>();
            var expected = expected2D.Cast<int>();
            Assert.Equal(expected, actual);
        }

        [Theory]
        [ClassData(typeof(HintsCalculatorHorizontalHintsTestData))]
        public void CalculateHorizontalHintsTest(int[,] input, List<int>[] expectedOutput)
        {
            _hintsCalculator = new HintsCalculator(input);
            var hints = _hintsCalculator.GetConsecuitiveHorizontalElements();
            var actual2D = ComplexColectionHelpers.ListArrayToJaggedArrayVertical(hints);
            var expected2D = ComplexColectionHelpers.ListArrayToJaggedArrayVertical(expectedOutput);
            var actual = actual2D.Cast<int>();
            var expected = expected2D.Cast<int>();
            Assert.Equal(expected, actual);
        }

        public void GetConsecuitiveVerticalElementsTest()
        {
        }

        public void GetConsecuitiveHorizontalElementsTest()
        {
        }
    }
}
