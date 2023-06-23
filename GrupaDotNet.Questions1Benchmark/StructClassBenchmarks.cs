using BenchmarkDotNet.Attributes;

namespace GrupaDotNet.Questions1Benchmark
{
    public class StructClassBenchmarks
    {
        [Params(20, 50, 100, 1000)]
        public int ArraySize { get; set; }

        [Benchmark]
        public void Struct()
        {
            var array = new StructA[ArraySize];
            for (int i = 0; i < ArraySize; i++)
            {
                array[i].A = i;
            }
        }

        [Benchmark]
        public void Class()
        {
            var array = new ClassA[ArraySize];
            for (int i = 0; i < ArraySize; i++)
            {
                array[i] = new ClassA
                {
                    A = i
                };
            }
        }

        [Benchmark]
        public void ClassWithFinalizator()
        {
            var array = new ClassB[ArraySize];
            for (int i = 0; i < ArraySize; i++)
            {
                array[i] = new ClassB();
            }
        }
    }

    class ClassA
    {
        public int A;
    }

    class ClassB
    {
        public int A;

        ~ClassB()
        {

        }

        //public bool Finalize()
        //{
        //    return true;
        //}
    }

    struct StructA
    {
        public int A;
    }
}

abstract class ClassBaseA
{

}

abstract class ClassBaseB
{

}

interface IInterfaceA
{

}
interface IInterfaceB
{

}

class ABC: ClassBaseA, IInterfaceA, IInterfaceB //ClassBaseB, <- nie można dziedziczyć z wielu klas
{
     

}