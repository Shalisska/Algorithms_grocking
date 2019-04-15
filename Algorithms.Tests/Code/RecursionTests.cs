using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Algorithms.Code;

namespace Algorithms.Tests.Code
{
    public class RecursionTests
    {
        [Theory]
        [InlineData(5, 0)]
        [InlineData(2, -2)]
        [InlineData(0, 0)]
        [InlineData(-2, 0)]
        public void Countdown(int from, int to)
        {
            var recursionService = new Recursion();
            var resultActual = recursionService.Countdown(from, to);

            if(from <= to)
            {
                Assert.Equal(from.ToString(), resultActual);
            }
            else
            {
                var list = new List<int>();
                for(var i = from; i >= to; i--)
                    list.Add(i);

                Assert.Equal(string.Join(' ', list), resultActual);
            }
        }

        [Theory]
        [InlineData(-3)]
        [InlineData(1)]
        [InlineData(5)]
        public void GetFactorial(int x)
        {
            var recursion = new Recursion();

            var resultActual = recursion.GetFactorial(x);

            if (x <= 1)
                Assert.Equal(1, resultActual);
            else
            {
                var resultExpected = 1;
                while (x > 1)
                {
                    resultExpected *= x;
                    x--;
                }

                Assert.Equal(resultExpected, resultActual);
            }
        }
    }
}
