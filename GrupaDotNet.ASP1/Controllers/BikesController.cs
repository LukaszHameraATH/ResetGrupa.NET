using GrupaDotNet.ASP1.DTOs;
using GrupaDotNet.ASP1.Infrastructure.Database;
using GrupaDotNet.ASP1.Model;
using Microsoft.AspNetCore.Mvc;

namespace GrupaDotNet.ASP1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BikesController : ControllerBase
    {
        // TAK nie robiæ
        //private static readonly BikeRepository _bikeRepository = new BikeRepository();

        private readonly IBikeRepository _bikeRepository;
        public BikesController(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        [HttpGet]
        public IEnumerable<BikeDTO> Get()
        {
            var bikes = _bikeRepository.GetAll();
            //...
            return bikes.Select(x=> new BikeDTO(x));
        }

        [HttpPost]
        public void Add(AddBikeDTO command)
        {
            var newBike = new Bike(command.Id, command.Name);
            //...
            _bikeRepository.Add(newBike);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            _bikeRepository.DeleteById(id);
        }
    }
}