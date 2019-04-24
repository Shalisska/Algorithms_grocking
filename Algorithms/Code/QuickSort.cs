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

        public int? FindItemIndexBinarySearch(IEnumerable<int> list, int item, int min, int max)
        {
            if (!list.Any() || max < min)
                return null;


            var mid = (min + max) / 2;
            var midItem = list.ElementAt(mid);
            if (midItem == item)
                return mid;

            return midItem > item ?
                FindItemIndexBinarySearch(list, item, min, mid - 1) :
                FindItemIndexBinarySearch(list, item, mid + 1, max);
        }

        public IEnumerable<int> QuickSorting(IEnumerable<int> list)
        {
            if (list.Count() <= 1)
                return list;

            var pivot = list.ElementAtOrDefault((list.Count() - 1) / 2);
            var less = list.Where(i => i < pivot);
            var greater = list.Where(i => i > pivot);

            return QuickSorting(less).Union(new int[] { pivot }).Union(QuickSorting(greater));
        }
    }
}
