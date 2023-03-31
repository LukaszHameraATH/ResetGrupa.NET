using GrupaDotNet.ASP1.Model;

namespace GrupaDotNet.ASP1.Infrastructure.Database
{
    public class EfBikeRepository: IBikeRepository
    {
        private readonly AppDbContext _dbContext;

        public EfBikeRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Bike> GetAll()
        {
            return _dbContext
                .Bikes
                .ToArray();
        }

        public void Add(Bike newBike)
        {
            _dbContext.Bikes.Add(newBike);
            _dbContext.SaveChanges();
        }

        public bool ContainsById(Guid id)
        {
            return _dbContext
                .Bikes
                .Any(x => x.Id == id);
        }

        public void DeleteById(Guid id)
        {
            var bike = _dbContext.Bikes.FirstOrDefault(x => x.Id == id);

            if (bike is not null)
            {
                _dbContext.Bikes.Remove(bike);
                _dbContext.SaveChanges();
            }
        }
    }
}
