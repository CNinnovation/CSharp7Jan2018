using NetStandardSample;
using System;

namespace DotnetCoreApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var d1 = new Demo();
            Console.WriteLine(d1.Add(38, 4));

            Console.WriteLine(d1.Hello("Katharina"));

          //  d1.Hello2("Stephanie");
        }
    }
}
