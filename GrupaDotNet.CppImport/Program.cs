using System.Runtime.InteropServices;

Console.WriteLine("Hello, World!");

// Wskazywanie, że GC nie rusza pamięci dla danego miejsca
var tab = new int[] { 1, 2, 3 }; // obiekt dynamiczny, więc GC działa

// #1 metoda 
var handle = GCHandle.Alloc(tab, GCHandleType.Pinned);
try
{
    var tabPtr = handle.AddrOfPinnedObject();
}
finally
{
    handle.Free();
}

var testStr = new Test();
handle = GCHandle.Alloc(testStr, GCHandleType.Pinned);
try
{
    var tabPtr = handle.AddrOfPinnedObject();
}
finally
{
    handle.Free();
}

// #2 metoda
unsafe 
{
    fixed (int* tabPtr = tab)
    //fixed (Test* testStrPtr = testStr)
    {
        var sum = SumFromDll(tabPtr, tab.Length + 2);
    }
}

if (Random.Shared.Next(1, 300) == 3)
{ 
    var consoleHandle = GetConsoleWindow();
}

// Kwestie do omówienia 
// - przesyłanie struktur,
// - string,
// - obiekty tworzone w c++

Console.ReadKey();

// Wczytywanie dllek 
// - statycznie - wczytywanie przy uruchomieniu, wraz z uruchominiem 
// - dynamicznie - wczytywanie kiedy chcemy, np. przed jakś operacją i później zwalniamy dllke

// C# (GC) -> C++ - normalnie, może GC zmienić miejsce w pamięci i to może powodować dziwne rzeczy np. losowe błędy, zmiane wartośći istniejących obietków, wyłączenie programu itp.
// C# (GC) -> wskazujemy, żeby GC nie zmieniał jakiejś części pamięći -> c++ - to jest jedyny poprawny sposób,
// C++ -> C# - obiekt dynamiczny, to musimy go zwolnić w c++

[DllImport("kernel12341441.dll")] // statyczne ładowanie dllki
static extern IntPtr GetConsoleWindow();

[DllImport("GrupaDotNet.CppDll.dll", EntryPoint = "sum_r")]
static extern unsafe int SumFromDll(int* tab, int tabCount);

struct Test
{

}

