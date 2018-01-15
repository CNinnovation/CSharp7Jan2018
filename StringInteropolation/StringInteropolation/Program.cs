using System;

namespace StringInteropolation
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "hello";
            int n = 42;
            Console.WriteLine($"text: {a}, {n}");

            int x = 3;
            int y = 4;
            Console.WriteLine($"the sum of {x} and {y} is {x + y}");

            FormattableString s2 = $"the sum of {x} and {y} is {x + y}";

            x = 42;
            Console.WriteLine(s2);
        }
    }
}
