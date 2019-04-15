using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Code
{
    public class SelectionSort
    {
        public int[] GetSortedArray(List<int> list)
        {
            var sortedArr = new int[list.Count];

            for(var i = 0; i < sortedArr.Length; i++)
            {
                var smallest = FindIndexOfSmallest(list);
                sortedArr[i] = list[smallest];
                list.RemoveAt(smallest);
            }

            return sortedArr;
        }

        private int FindIndexOfSmallest(List<int> list)
        {
            var smallest = list[0];
            var smallestindex = 0;

            for(var i = 1; i < list.Count; i++)
            {
                if (list[i] < smallest)
                {
                    smallest = list[i];
                    smallestindex = i;
                }
            }

            return smallestindex;
        }
    }
}
