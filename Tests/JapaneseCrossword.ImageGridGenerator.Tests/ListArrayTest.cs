using System.Collections;
using System.Collections.Generic;

namespace ImageGridGeneratorTests
{
    internal class ListArrayTest: IEnumerable<object[]>
    {

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { Input1, ExpectedOutput1 };
            yield return new object[] { Input2, ExpectedOutput2 };
            yield return new object[] { Input3, ExpectedOutput3 };
        }

        private List<int>[] Input1
        {
            get
            {
                var array = new List<int>[4];
                var list1 = new List<int>() { 1, 2, 3, 4 };
                var list2 = new List<int>() { 1, 4 };
                var list3 = new List<int>() { 1, 3, 4 };
                var list4 = new List<int>() { 1 };
                array[0] = list1;
                array[1] = list2;
                array[2] = list3;
                array[3] = list4;
                return array;
            }

        }

        private int[,] ExpectedOutput1 => new[,]
        {
            {1, 2, 3, 4},
            {1, 4, 0, 0},
            {1, 3, 4, 0},
            {1, 0, 0, 0}
        };


        private List<int>[] Input2
        {
            get
            {
                var array = new List<int>[4];
                var list1 = new List<int>() { 1 };
                var list2 = new List<int>() { 1 };
                var list3 = new List<int>() { 1 };
                var list4 = new List<int>() { 1 };
                array[0] = list1;
                array[1] = list2;
                array[2] = list3;
                array[3] = list4;
                return array;
            }
        }

        private int[,] ExpectedOutput2 => new[,]
        {
            {1},
            {1},
            {1},
            {1}
        };


        private List<int>[] Input3
        {
            get
            {
                var array = new List<int>[0];
                return array;
            }
        }

        private int[,] ExpectedOutput3 => new int[0, 0];


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}