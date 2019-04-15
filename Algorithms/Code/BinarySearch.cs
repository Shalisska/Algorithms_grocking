using Algorithms.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Code
{
    public class BinarySearch
    {
        public int? FindItemIndexBinarySearch(IList<int> list, int item)
        {
            var low = 0;
            var high = list.Count - 1;

            var counter = 0;

            while (low <= high)
            {
                counter++;
                Console.WriteLine(counter);

                var middle = (low + high) / 2;
                var guess = list[middle];

                if (guess == item)
                    return middle;
                if (guess < item)
                    low = middle + 1;
                else
                    high = middle - 1;
            }

            return null;
        }

        public void BinarySearchExample()
        {
            var listData = new SortedListForBinarySearch();
            var list = listData.SortedListForBinarySearchEx1;

            var item = 0;
            var result = FindItemIndexBinarySearch(list, item);
            Console.WriteLine($"Index of {item}: {result}");

            item = 47;
            result = FindItemIndexBinarySearch(list, item);
            Console.WriteLine($"Index of {item}: {result}");
        }
    }
}
