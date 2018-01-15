using System;
using System.Buffers;

namespace SpanDemo
{
    ref struct X
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "this is a string";
            Span<char> span1 = new Span<char>(s1.ToCharArray());
            Span<char> span2 = span1.Slice(5);

            // Console.WriteLine(span2.ToString());


            int[] arr1 = ArrayPool<int>.Shared.Rent(3);
            Console.WriteLine(arr1.Length);
            ArrayPool<int>.Shared.Return(arr1);
        }
    }
}
