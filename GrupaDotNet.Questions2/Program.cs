// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Numerics;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

Console.WriteLine("Hello, World!");

var test = new GenericClass<int>();
var test2 = new GenericClass<GenericClass<string>>();
var test3 = new GenericClass<object>();

var test4 = new GenericClass2<object>();
//var test5 = new GenericClass2<int>(); // błąd

var test6 = new GenericClass3<Point>();
//var test7 = new GenericClass3<object>(); // bład

var test8 = new GenericClass7<int>();
var test9 = new GenericClass7<Point>();
//var test10 = new GenericClass7<StructTest>();

var test11 = new GenericClass8<int>();
var test12 = new GenericClass8<float>();
//var test13 = new GenericClass8<Point>();

IServiceCollection serviceCollection = new ServiceCollection();
serviceCollection.AddTransient<ClassToRegister>();
serviceCollection.AddScoped<ClassToRegister2>();

using var provider = serviceCollection.BuildServiceProvider();
var service1 = provider.GetRequiredService<ClassToRegister>();
service1 = provider.GetRequiredService<ClassToRegister>();
service1 = provider.GetRequiredService<ClassToRegister>();
service1 = provider.GetRequiredService<ClassToRegister>();

using var scope = provider.CreateScope();
var service2 = scope.ServiceProvider.GetRequiredService<ClassToRegister2>();
service2 = scope.ServiceProvider.GetRequiredService<ClassToRegister2>();

using var scope2 = provider.CreateScope();
service2 = scope2.ServiceProvider.GetRequiredService<ClassToRegister2>();
service2 = scope2.ServiceProvider.GetRequiredService<ClassToRegister2>();

int[] items = new int[] { 1, 2, 3, 4 };
var items2 = items.Select(x => x * 2).ToArray();

var items3 = new int[][]
{
    new int[]{1,2},
    new int[]{3,4}
};
var items4 = items3.SelectMany(x => x).ToArray();

lock (items)
{
    // await AsyncOp();błąd
}

var test123 = Test123();
var test1234 = Test123();

// dynamic nie używać, 
dynamic awc = 1;
awc = "string";
awc = 1.2;
awc = 1.2f;
awc = new object();

var jsonDynamic = JsonConvert.DeserializeObject<dynamic>("""[{name:"test"},{"value":3}]""");



//

var text = "123";

var numbersEnumerable = Enumerable.Range(0, 1_000_000_0).Where(x=>x>20).OrderByDescending(x=>x).Reverse().Where(x=>Math.Sqrt(x) > 0);
var numbers = numbersEnumerable.ToArray();

var an = new
{
    Name = "123",
    Value = 2
};
var anFu = (int x) => x * 2;

numbers
    .Select((x, i) => new { index = i, value = x })
    .Where(x => x.index > 500)
    .Select(x => x.value);

text = $"{123}";

const string StringInt = $"Od C# {"10"}/ .NET {"7"} można robić dolary w const"; // Sprawdzić, jak nie to is do MC
Console.ReadLine();

Task AsyncOp()
{
    return Task.CompletedTask;
}

double Test123()
{
    return 1;
}

int Test()
{

    try
    {

    }
    finally
    {
        // throw new Exception();
        var test = Test123();
        //return 2;
    }
    return 2;
}

class GenericClass<T> // każdy typ do T możemy dać
{

}

class GenericClass2<T> where T: class
{

}

class GenericClass3<T> where T : struct
{

}
class GenericClass4<T> where T: struct
{
    public void Test()
    {
        var item = new T();
    }
}
class GenericClass5<T> where T : class, new() // <- oznacza że klasa musi mieć ctor bezparametrowy
{
    public void Test()
    {
        var item = new T(); // <- bez tego new() mamy błąd
    }
}

class GenericClass6<T> where T : IDisposable
{
    public void Test(T item)
    {
        item?.Dispose();
    }
}

class GenericClass7<T> where T : unmanaged //<- wartościowe, struktury, ale bez referencji
{
    public void Test(T item)
    {
        
    }
}

struct StructTest
{
    string Test;
}


class GenericClass8<T> where T : INumber<T> // tylko numery od .NET7 (2022)
{
    public T Sum(T[] items)
    {
        var sum = T.Zero;
        for (int i = 0; i < items.Length; i++)
            sum += items[i];
        return sum;
    }

    public G? Sum<G>() where G: class
    {
        return default;
    }
}

class ClassToRegister
{
    public ClassToRegister()
    {
        
    }
}

class ClassToRegister2
{
    public ClassToRegister2()
    {

    }
}

abstract class BaseClass
{
    protected virtual void Test()
    {

    }

    public abstract void Test2();
}

class InhClass : BaseClass
{
    public override void Test2()
    {
        throw new NotImplementedException();
    }

    //virtual int G;

    public virtual int B
    { 
        get;
    }

    event EventHandler<int> A;
}

interface IInterface
{
    event EventHandler<int> A;
}