using GrupaDotNet.ASP1.Model;

namespace GrupaDotNet.ASP1.DTOs
{
    public class BikeDTO
    {
        public BikeDTO(Bike bike)
        {
            Id = bike.Id;
            Name = bike.Name;
        }

        public Guid Id { get; }
        public string Name { get; }
    }
}
