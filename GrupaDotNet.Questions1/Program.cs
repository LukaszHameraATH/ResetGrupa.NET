
using System.IO;

var numbers = new int[]{1,2,3,4,5,6,7,8,9,10};
numbers = Enumerable.Range(1, 10).Reverse().ToArray();

// 1. LINQ które z tablicy liczb wybiera parzyste, nastepnie kwadrat liczb i posortowane rosnąco
var res1 = numbers.Where(x=>x%2==0).Select(x=>x*x).OrderBy(x=>x);

// 2. klasa a struktura w c#

ClassA classA; // null
StructA structA; // jakaś struktura, nie null, nie można przypisać nulla

var classB = new ClassA();
var classC = classB; // przypisujemy referencję

classC.A = 100; // zmiana w classC i classB - refrencja

StructA structB = new StructA();
StructA structC = structB; // przypisujemy kopię

structC.A = 100; // zmiana tylko w structC

//var fileStream = new FileStream("test.png", FileMode.Create);
//try
//{

//}
//finally
//{
//    fileStream.Dispose();
//}

//using (var fileStream = new FileStream("test.png", FileMode.Create))
//using (var fileStream2 = new FileStream("test.png", FileMode.Create))
//{
//    //..
//}

// using var fileStream = new FileStream("test.png", FileMode.Create);

//HTPP server z ASP.NET

var q6 = new ClassA[]
{
    new ClassA { A = 1 },
    new ClassA { A = 1 },
    new ClassA { A = 2 },
    new ClassA { A = 3 },
};

//var q6F = q6.FirstOrDefault(x => x.A == 1);
//var q6S = q6.SingleOrDefault(x => x.A == 1);

try
{
    var q7 = q6.AsParallel().Where(x => x.A > 0).Select(x =>
    {
        throw new Exception();
        return 1;
    }).ToArray();
}
catch (Exception e)
{
    Console.WriteLine(e);
}

//TestAsync();

//while (true)
//{
//    Thread.Sleep(10);
//}

var q11 = Activator.CreateInstance<ClassA>();

Console.ReadLine();

void TesT(int a)
{
    int b;
}

// nie robić
async void TestAsync()
{
    await Task.Delay(1000);
    throw new Exception();
}

class ClassA
{ 
    public int A;
}

struct StructA
{
    // od .NETa 7, nie musiumy przypisywać wszystkich pól/ właściwości w ctorze
    public StructA()
    {
        
    }
    public int A { get; set; }
}

class ClassC : IDisposable
{
    private FileStream _fileStream;

    #region DisposePattern
    public void Dispose() => Dispose(true);

    private bool _disposed = false;
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            // TODO: dispose managed state (managed objects).
        }

        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
        // TODO: set large fields to null.

        _disposed = true;
    }

    #endregion
}


//BenchmarkDotNet = v0.13.5, OS = Windows 11(10.0.25375.1)
//11th Gen Intel Core i7-11850H 2.50GHz, 1 CPU, 16 logical and 8 physical cores
//.NET SDK=7.0.202
//  [Host]     : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2
//  DefaultJob : .NET 7.0.4 (7.0.423.11508), X64 RyuJIT AVX2


//|               Method | ArraySize |          Mean |         Error |       StdDev |
//|--------------------- |---------- |--------------:| --------------:| -------------:|
//| Struct | 20 | 29.13 ns | 5.020 ns | 14.32 ns |
//| Class | 20 | 346.46 ns | 26.785 ns | 78.98 ns |
//| ClassWithFinalizator | 20 | 6,805.60 ns | 299.443 ns | 878.21 ns |
//| Struct | 50 | 122.60 ns | 10.767 ns | 31.58 ns |
//| Class | 50 | 720.86 ns | 59.668 ns | 175.93 ns |
//| ClassWithFinalizator | 50 | 21,241.92 ns | 1,496.036 ns | 4,411.10 ns |
//| Struct | 100 | 256.03 ns | 27.749 ns | 81.82 ns |
//| Class | 100 | 1,998.32 ns | 96.477 ns | 284.47 ns |
//| ClassWithFinalizator | 100 | 37,497.24 ns | 1,641.796 ns | 4,840.87 ns |
//| Struct | 1000 | 2,130.02 ns | 111.576 ns | 328.99 ns |
//| Class | 1000 | 17,689.76 ns | 1,183.071 ns | 3,488.31 ns |
//| ClassWithFinalizator | 1000 | 251,101.83 ns | 16,767.375 ns | 49,175.81 ns |