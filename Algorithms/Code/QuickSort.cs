using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Code
{
    public class QuickSort
    {
        public int LoopSum(IEnumerable<int> numbers)
        {
            var total = 0;

            foreach (var number in numbers)
                total += number;

            return total;
        }

        public int RecursiveSum(IEnumerable<int> list)
        {
            if (!list.Any())
                return 0;

            return list.Take(1).First() + RecursiveSum(list.Skip(1));
        }

        public int ElementsCounter(IEnumerable<int> list)
        {
            if (!list.Any())
                return 0;

            return 1 + ElementsCounter(list.Skip(1));
        }

        public int FindMax(IEnumerable<int> list)
        {
            if (!list.Any())
                throw new ArgumentException(nameof(list));

            if (list.Count() == 1)
                return list.First();

            if (list.Count() == 2)
                return list.First() > list.Last() ? list.First() : list.Last();

            var subMax = FindMax(list.Skip(1));
            return list.First() > subMax ? list.First() : subMax;
        }
    }
}
