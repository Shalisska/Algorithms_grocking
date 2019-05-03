using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Code
{
    public class DynamicProgramming
    {
        public void TetrisBag()
        {
            var items = new Dictionary<string, (double Price, double Weight)>
            {
                //["stereo"] = (3000, 4),
                //["laptop"] = (2000, 3),
                //["guitar"] = (1500, 1),
                //["iphone"] = (2000, 1),
                //["necklace"] = (1000, 0.5),
                //["diamond"] = (1000000, 3.5)

                ["water"] = (10, 3),
                ["book"] = (3, 1),
                ["food"] = (9, 2),
                ["cloth"] = (5, 2),
                ["photo"] = (6, 1)
            };

            var bagWeight = 6d;
            var minWeight = items.Min(item => item.Value.Weight);
            var columnCount = (int)(bagWeight / minWeight);

            var columnValues = new double[columnCount];
            for (var j = 1; j <= columnValues.Length; j++)
            {
                columnValues[j - 1] = minWeight * j;
            }

            var table = new (HashSet<string> Elements, double Price)[items.Count, columnCount];
            var i = 0;

            foreach (var item in items)
            {
                for (var j = 0; j < columnCount; j++)
                {
                    var freeWeight = columnValues[j] - item.Value.Weight;
                    var maxValue = i != 0 ? table[i - 1, j] : (new HashSet<string>(), 0);
                    var currentCell = maxValue;

                    if (freeWeight == 0 && item.Value.Price > maxValue.Price)
                        currentCell = (new HashSet<string> { item.Key }, item.Value.Price);
                    if (freeWeight > 0)
                    {
                        var index = (int)(freeWeight / minWeight) - 1;
                        var cellWithoutCurrentElement = i == 0 ? (new HashSet<string>(), 0) : table[i - 1, index];

                        var newPrice = cellWithoutCurrentElement.Price + item.Value.Price;
                        if (newPrice > maxValue.Price)
                        {
                            currentCell = (new HashSet<string>(cellWithoutCurrentElement.Elements) { item.Key }, newPrice);
                        }
                    }

                    table[i, j] = maxValue.Price > currentCell.Price ? maxValue : currentCell;
                }
                i++;
            }

            var (Elements, Price) = table[items.Count - 1, columnCount - 1];
            Console.WriteLine(Elements.Count);
            Console.WriteLine(Price);
            foreach (var res in Elements)
            {
                Console.WriteLine(res);
            }
        }

        public void MaxSubstring()
        {
            var word_1 = "blue";
            var word_2 = "clues";

            var table = new int[word_1.Length, word_2.Length];

            for (var i = 0; i < word_1.Length; i++)
            {
                for(var j = 0; j < word_2.Length; j++)
                {
                    var letter_1 = word_1[i];
                    var letter_2 = word_2[j];

                    var leftCell = j > 0 ? table[i, j - 1] : 0;
                    var crossCell = (i > 0 && j > 0) ? table[i - 1, j - 1] : 0;
                    var upperCell = i > 0 ? table[i - 1, j] : 0;


                    if (word_1[i] == word_2[j])
                        table[i, j] = crossCell + 1;
                    else
                        table[i, j] = Math.Max(upperCell, leftCell);
                }
            }

            Console.Write("  ");
            foreach(var item in word_2)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();

            for(var i = 0; i < word_1.Length; i++)
            {
                Console.Write($" {word_1[i]}");
                for(var j = 0; j < word_2.Length; j++)
                {
                    Console.Write($" {table[i, j]}");
                }
                Console.WriteLine();
            }
        }
    }
}
