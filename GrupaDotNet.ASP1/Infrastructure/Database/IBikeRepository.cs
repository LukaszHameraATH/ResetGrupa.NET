using GrupaDotNet.ASP1.Model;

namespace GrupaDotNet.ASP1.Infrastructure.Database
{
    public interface IBikeRepository
    {
        public IEnumerable<Bike> GetAll();

        public void Add(Bike newBike);

        public bool ContainsById(Guid id);

        public void DeleteById(Guid id);

    }
}
