using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Algorithms.Code;

namespace Algorithms.Tests.Code
{
    public class SelectionSortTests
    {
        [Fact]
        public void GetSortedArrayTests()
        {
            var arr = new List<int> { 5, 3, 6, 2, 10 };
            var sorter = new SelectionSort();

            var resultExpected = arr.OrderBy(i => i).ToArray();
            var resultActual = sorter.GetSortedArray(arr);

            Assert.Equal(string.Join(' ', resultExpected), string.Join(' ', resultActual));
        }
    }
}
