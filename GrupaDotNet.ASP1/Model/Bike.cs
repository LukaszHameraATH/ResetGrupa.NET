namespace GrupaDotNet.ASP1.Model
{
    public class Bike
    {
        private Bike()
        {

        }

        public Bike(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
