using GrupaDotNet.ASP1.Model;

namespace GrupaDotNet.ASP1.Infrastructure.Database
{
    public class DictionaryBikeRepository: IBikeRepository
    {
        private readonly Dictionary<Guid, Bike> _bikes = new Dictionary<Guid, Bike>();

        public IEnumerable<Bike> GetAll()
        {
            return _bikes.Values;
        }

        public void Add(Bike newBike)
        {
            _bikes.Add(newBike.Id, newBike);
        }

        public bool ContainsById(Guid id)
        {
            return _bikes.ContainsKey(id);
        }

        public void DeleteById(Guid id)
        {
            _bikes.Remove(id);
        }
    }
}
