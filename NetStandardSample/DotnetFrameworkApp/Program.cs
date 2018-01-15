using NetStandardSample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetFrameworkApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var d1 = new Demo();
            Console.WriteLine(d1.Add(38, 4));
            Console.WriteLine(d1.Hello("Katharina"));

            d1.Hello2("Stephanie");
        }
    }
}
