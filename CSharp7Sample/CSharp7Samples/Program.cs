using CSharp7Samples;
using CSharp7Samples.Models;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Threading.Tasks;

class Program
{
    static void Main(string[] args)
    {
        //   BinaryLiteralsAndDigitSeparators();
        // RefLocalAndRefReturn();
        //OutVars();
        // ValueTaskSample();
        // LocalFunctions();
        // Localfunctions2();
        // LambdaExpressionsEverywhere();
        //FlexibleAwait();
        //ThrowExpressions();
        PatternMatching();
        // TuplesAndDeconstruction();
    }

    private static void Localfunctions2()
    {
        var data = new int[] { 3, 4, 5 };
        var q = data.Filter(null);

        foreach (var item in q)
        {
            Console.WriteLine(item);
        }
    }

    private async static void ValueTaskSample()
    {
        int result = await SomeTask();
        Console.WriteLine(result);
    }

    public static ValueTask<int> SomeTask()
    {
        return new ValueTask<int>(42);
    }

    private static void BinaryLiteralsAndDigitSeparators()
    {
        Console.WriteLine(nameof(BinaryLiteralsAndDigitSeparators));

        int n1 = 788_673_464;
        int b1 = 0b_0101_1011______1101;

        Console.WriteLine();
    }

    private static void RefLocalAndRefReturn()
    {
        Console.WriteLine(nameof(RefLocalAndRefReturn));
        //int[] data = { 1, 2, 3, 4 };
        //ref int x = ref GetByIndex(2);
        //x = 42;
        //Console.WriteLine(x);
        //Console.WriteLine(data[2]);

        ref int a2 = ref GetTest();
        int[] a3 = ArrayPool<int>.Shared.Rent(100);
        Console.WriteLine($"a3: {a3[0]}");
        Console.WriteLine($"a2: {a2}");
        a3[0] = 42;
        Console.WriteLine(a2);

        Console.WriteLine();
    }

    private static ref int GetByIndex(int ix)
    {
        int[] data = { 7, 8, 9 };
        //   int z = 3;
        ref int a = ref data[ix];

        return ref a;
    }

    private static ref int GetTest()
    {
        // int[] data = ArrayPool<int>.Shared.Rent(100);
        var pool = ArrayPool<int>.Create();
        int[] data = pool.Rent(100);
        data[0] = 11;
        ref int a1 = ref data[0];
        //  ArrayPool<int>.Shared.Return(data);
        pool.Return(data);
        pool = null;
        GC.Collect(0, GCCollectionMode.Forced);
        GC.Collect(0, GCCollectionMode.Forced);
        GC.WaitForFullGCComplete();
        return ref a1;
    }


    private static void OutVars()
    {
        Console.WriteLine(nameof(OutVars));
        Console.WriteLine("enter a number:");
        string input = Console.ReadLine();
        bool success = int.TryParse(input, out int result);
        if (success)
        {
            Console.WriteLine($"this number: {result}");
        }
        else
        {
            Console.WriteLine("NaN");
        }
        Console.WriteLine();
    }

    private static void LocalFunctions()
    {
        Console.WriteLine(nameof(LocalFunctions));

        Func<int, int, int> f1 = (x, y) => x + y;

        int Add(int x, int y) => x + y;


        int result = Add(3, 2);
        Console.WriteLine(result);

        Console.WriteLine();
    }



    private static void LambdaExpressionsEverywhere()
    {
        Console.WriteLine(nameof(LambdaExpressionsEverywhere));

        Person p1 = new Person("Katharina Nagel");
        Console.WriteLine(p1.FirstName);

        Console.WriteLine();
    }

    private static void FlexibleAwait()
    {
        Console.WriteLine(nameof(FlexibleAwait));

        Console.WriteLine();
    }

    private static void ThrowExpressions()
    {
        Console.WriteLine(nameof(ThrowExpressions));
        int x = 42;

        int y = 0;
        if (x <= 42)
        {
            y = x;
        }
        else
        {
            throw new Exception("bad value");
        }

        Console.WriteLine($"y: {y}");
        Console.WriteLine();
    }

    private static void PatternMatching()
    {
        Console.WriteLine(nameof(PatternMatching));
        object[] data = { 42, "astring", (42, "one"), new Person("Matthias Nagel"), null, new Person("Katharina Nagel") };

        //foreach (var item in data)
        //{
        //    IsPattern(item);
        //}

        foreach (var item in data)
        {
            SwitchPattern(item);
        }

        Console.WriteLine();
    }

    public static void IsPattern(object o)
    {
        if (o is 42)  // const pattern
        {
            Console.WriteLine("const pattern - 42");
        }
        if (o is int n) // type pattern
        {
            Console.WriteLine($"it's int - {n}");
        }

        if (o is Person p && p.FirstName.StartsWith("Ka"))
        {
            Console.WriteLine($"Person match Ka {p.FirstName}");
        }

        if (o is var v)  // var pattern
        {
            Console.WriteLine($"var pattern, type: {v?.GetType().Name}");
        }
    }

    public static void SwitchPattern(object o)
    {
        switch (o)
        {
            case 42:
                Console.WriteLine("const pattern - 42");
                break;
            case ValueTuple<int, string> v2:
                Console.WriteLine($"tuple {v2.Item1}");
                break;
            case null:
                Console.WriteLine("const pattern - null");
                break;
            case int n:
                Console.WriteLine($"type pattern - int: {n}");
                break;
            case Person p when p.FirstName.StartsWith("K"):
                Console.WriteLine($"type pattern - Person {p.FirstName}");
                break;
            case Person p:
                Console.WriteLine("it's a person");
                break;
            case var v1:
                Console.WriteLine($"var pattern - {v1}");
                break;

        }
    }

    private static void TuplesAndDeconstruction()
    {
        Console.WriteLine(nameof(TuplesAndDeconstruction));

        (int x, string s) = (42, "magic");
        var t1 = Divide(11, 3);
        Console.WriteLine(t1.result);
        Console.WriteLine(t1.remainder);

        (int res, int rem) = Divide(22, 14);
        Console.WriteLine(res);

        var t2 = (x: 42, y: 11);
        Console.WriteLine(t2.x);

        ValueTuple<int, int> v1 = new ValueTuple<int, int>();
        v1.Item1 = 11;

        //Tuple<int, int> t3 = Tuple.Create(11, 12);
        //t3.Item1 = 42;

        List<(int a, string b)> list1 = new List<(int a, string b)>();
        list1.Add((42, "one"));
        int x2 = list1[0].a;


        Console.WriteLine(x);
        Console.WriteLine(s);


        var p1 = new Person("Stephanie Nagel");
        (string first, _, _) = p1;

        var list = new List<Person>() { p1 };
        foreach ((_, string last1, _) in list)
        {
            Console.WriteLine(last1);
        }

        (var vorname, _, _) = p1;

        Console.WriteLine();
    }

    private static (int result, int remainder) Divide(int x, int y)
    {
        int res = x / y;
        int rem = x % y;
        return (res, rem);
    }
}