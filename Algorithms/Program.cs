using System;
using Algorithms.Data;
using Algorithms.Code;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            var recursion = new Recursion();

            //recursion.CountdownConsole(5);
            //recursion.Greet("Hel");
            Console.WriteLine(recursion.GetFactorial(5));

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
