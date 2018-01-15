using System;
using static System.Console;
using static UsingStatic.MyNames;

namespace UsingStatic
{
    class MyNames
    {
        public const string Demo1 = nameof(Demo1);
        public const string Demo2 = nameof(Demo2);
    }

    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");

            string s2 = "Demo1";
            string s1 = Demo1;
        }
    }
}
