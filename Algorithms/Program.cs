using System;
using Algorithms.Data;
using Algorithms.Code;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //var recursion = new Recursion();

            //recursion.CountdownConsole(5);
            //recursion.Greet("Hel");
            //Console.WriteLine(recursion.GetFactorial(5));

            //var service = new BreadthFirstSearch();
            //var result = service.SearchSeller("you");
            //Console.WriteLine(result);

            var serviceDijkstras = new DijkstrasAlgorithm(1);
            var result = serviceDijkstras.GetResult();

            Console.WriteLine($"Nodes count: {result.Count}");
            Console.WriteLine($"Total cost: {result.Values.Sum()}");

            foreach(var node in result)
            {
                Console.WriteLine($"node: {node.Key}, cost: {node.Value}");
            }

            Console.ReadKey();
        }

        public static decimal GetDecimalPrice(string price)
        {
            if (decimal.TryParse(price, out var result))
                return result;

            return result;
        }

        public static void ChechDecimal()
        {
            Console.WriteLine(GetDecimalPrice("10"));
            Console.WriteLine(GetDecimalPrice(" "));
            Console.WriteLine(GetDecimalPrice("11 000"));
            Console.WriteLine(GetDecimalPrice(string.Empty));
            Console.WriteLine(GetDecimalPrice("1000.30"));
            Console.WriteLine(GetDecimalPrice("20,60"));
            Console.WriteLine(GetDecimalPrice("0"));
        }
    }
}
