namespace GrupaDotNet.API.Models
{
    public interface ITest
    {
        void Test();
    }

    internal class TestClass : ITest
    {
        public void Test()
        {
        }
    }
}
