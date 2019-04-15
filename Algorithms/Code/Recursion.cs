using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithms.Code
{
    public class Recursion
    {
        public string Countdown(int from, int to, List<int> list = null)
        {
            if (list == null)
                list = new List<int>();

            list.Add(from);

            if (from > to)
                Countdown(from - 1, to, list);

            return string.Join(' ', list);
        }

        public void CountdownConsole(int i)
        {
            Console.WriteLine(i);

            if (i <= 0)
                return;

            CountdownConsole(i - 1);
        }

        public void Greet(string name)
        {
            Console.WriteLine($"Hello, {name}.");
            Greet2(name);
            Console.WriteLine("Ready to say bye...");
            Bye();
        }

        private void Greet2(string name)
        {
            Console.WriteLine($"How are you, {name}?");
        }

        private void Bye()
        {
            Console.WriteLine("Bye!");
        }

        public int GetFactorial(int x)
        {
            if (x <= 1)
                return 1;

            return x * GetFactorial(x - 1);
        }
    }
}
