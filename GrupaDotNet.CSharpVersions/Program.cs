using BenchmarkDotNet.Running;
using GrupaDotNet.CSharpVersions;
using System.Numerics;
using OwnType = float;

// var array = new int[3];
// Span<int> arrayStatic = stackalloc int[3];
    
// BenchmarkRunner.Run<SpanBenchmark>();
 // BenchmarkRunner.Run<MagicBenchmark>();
// return;
    
var values = new OwnType[] { 1, 4, 5.5f, 20.0f, 1, 2,3 ,4 ,5 ,6,7 };
var sum = Sum<OwnType>(values);
Console.WriteLine(sum);

ReadOnlySpan<OwnType> spanValues = values;
spanValues = spanValues.Slice(4);

var text = "Test test test";
ReadOnlySpan<char> textSpan = text;
textSpan = textSpan.Slice(5, 4);

var test = (int a = 10) => Console.WriteLine(a);
test();
test(20);

var test1 = new Test(1);

var test2 = new TestClass()
{
    InitProperty = 1
};
var test3 = new TestClass()
{
    InitProperty = 1
};


Console.ReadLine();
T Sum<T>(ReadOnlySpan<T> values) where T : INumber<T>
{
    var sum = T.Zero;
    foreach (var value in values)
        sum += value;
    return sum;
}

public record Test(int A);

public class TestClass
{
    public A AProp { get; set; }
    public required int InitProperty { get; init; }

    public void Test(A parm)
    {
        
    }

    private A _testStruct;
    public ref A Test1()
    {
        return ref _testStruct;
    }
}

public readonly struct A
{
    public readonly int Value;

    public void Change()
    {
    }
}

