using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Algorithms.Code;
using System.Linq;

namespace Algorithms.Tests.Code
{
    public class QuickSortTests
    {
        [Fact]
        public void RecursiveSumTest()
        {
            var sorter = new QuickSort();
            var list = new[] { 1, 2, 3, 4 };

            var resultExpected = 0;
            var resultActual = sorter.RecursiveSum(list);

            foreach (var item in list)
                resultExpected += item;

            Assert.Equal(resultExpected, resultActual);
        }

        [Fact]
        public void ElementsCounterTest()
        {
            var sorter = new QuickSort();
            var list = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var resultExpected = list.Length;
            var resultActual = sorter.ElementsCounter(list);

            Assert.Equal(resultExpected, resultActual);
        }

        [Theory]
        [InlineData(new int[] { })]
        [InlineData(new[] { 1 })]
        [InlineData(new[] { 3, 2})]
        [InlineData(new[] { 1, 2, 6, 7, 8, 3, 4, 9, 5 })]
        public void FindMaxTest(int[] arr)
        {
            var sorter = new QuickSort();

            if (!arr.Any())
                Assert.Throws<ArgumentException>(() => sorter.FindMax(arr));
            else
            {
                var resultExpected = arr.Max();
                var resultActual = sorter.FindMax(arr);

                Assert.Equal(resultExpected, resultActual);
            }
        }
    }
}
