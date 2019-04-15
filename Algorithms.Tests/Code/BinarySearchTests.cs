using Algorithms.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Algorithms.Tests.Code
{
    public class BinarySearchTests
    {
        [Theory]
        [InlineData(-5)]
        [InlineData(20)]
        public void FindItemIndexBinarySearchTests(int value)
        {
            var list = new List<int> { -5, 1, 3, 5, 7, 9 };
            var search = new BinarySearch();

            var resultExpected = list.IndexOf(value);
            var resultActual = search.FindItemIndexBinarySearch(list, value);

            if (resultExpected < 0)
            {
                Assert.Null(resultActual);
            }
            else
            {
                Assert.Equal(resultExpected, resultActual);
            }
        }
    }
}
