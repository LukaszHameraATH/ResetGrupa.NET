using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("GrupaDotNet.Questions2")] // <- dostęp do typów internal w projekcie GrupaDotNet.Questions2

var abc = new ABC();
abc.Test();

var abcType = typeof(ABC);
var abcType2 = abc.GetType();

var abcTestMethod = abcType.GetMethod("Test");
abcTestMethod.Invoke(abc, Array.Empty<object>());

var abcType3 = Activator.CreateInstance<ABC>();

var dateTime = DateTime.Now;
DateTime? dateTime2 = null;
Nullable<DateTime> dateTime3 = null;

var lazyInt =
    new Lazy<int>(() => Enumerable.Range(0, 1_000).OrderByDescending(x => x).Where(x => x > 100).Sum());

Console.WriteLine("TEst123");
Console.WriteLine("TEst123");
Console.WriteLine("TEst123");

Console.WriteLine(lazyInt.Value);
Console.WriteLine(lazyInt.Value);

// EF - ustawia dane
// Serialiacja/ deserializacja


using (var stream = new MemoryStream())
{

}

using var stream2 = new MemoryStream();

var text = "ABC";
//text[0] = 'C';

var @record = new Record("ABC");
var classRecord = new RecordClass
{
    ABC = "test"
};

//classRecord.ABC = "TEST!@#";

var point = new PointRecord(1, 2);
var (x, y) = point;

var pointWithDiffY = new PointRecord(point.X, 123);
var pointWithDiffY2 = point with { Y = 123 };

var dictionary = new Dictionary<string, string>();
if (dictionary.TryGetValue("123", out var value))
    Console.WriteLine("JEst");

Console.ReadLine();

void RefMethod(ref Record record)
{
    record = new Record("123");
}

//bool OutMethod(out Record record)
//{
//    record = 
//}

void InMethod(in Record record)
{
    record = new Record("cawe");
}

record struct RecordStruct(string ABC);

record Record(string ABC);

record PointRecord(int X, int Y);

class RecordClass
{
    public RecordClass()
    {
        
    }
    public RecordClass(string abc)
    {
        ABC = abc;
    }
    public required string ABC { get; init; }
}

internal sealed class ClassABC
{
    private class PrivateClass
    {

    }
}

//class ClassABCD : ClassABC
//{

//}

class ABC
{
    public void Test()
    {
        Console.WriteLine("ABC");
    }
}

static class Data
{
    public const string ABC = "";
}
