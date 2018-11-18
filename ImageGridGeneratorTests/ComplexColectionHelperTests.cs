using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImageGridGenerator;
using Xunit;

namespace ImageGridGeneratorTests
{
   public class ComplexColectionHelperTests
    {
        [Theory]
        [ClassData(typeof(ListArrayTest))]
        public void ListArrayToJaggedArrayTest(List<int>[] listArray, int[,] expectedResult)
        {
            var result = ComplexColectionHelpers.ListArrayToJaggedArrayVertical(listArray);
            var actual1D = result.Cast<int>();
            var expected1D = expectedResult.Cast<int>();
            Assert.Equal(expected1D, actual1D);
        }

        [Theory]
        [ClassData(typeof(ArrayInvertTestData))]
        public void TestInversionOfArray(int[,] input, int[,] expectedOutput)
        {
            var result = input.InvertOrientation();
            var actual1D = result.Cast<int>();
            var expected1D = expectedOutput.Cast<int>();
            Assert.Equal(expected1D, actual1D);
        }
    }
}
