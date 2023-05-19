using GrupaDotNet.CQRS.Lib.Commands;
using GrupaDotNet.CQRS.Lib.Queries;
using GrupaDotNet.CQRS.Meteorology;
using Microsoft.AspNetCore.Mvc;

namespace GrupaDotNet.CQRS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private readonly AddWeatherForecastHandler _addWeatherForecastHandler;
        //private readonly GetAllWeatherForecastHandler _getAllWeatherForecastHandler;
        //public WeatherForecastController(AddWeatherForecastHandler addWeatherForecastHandler, GetAllWeatherForecastHandler getAllWeatherForecastHandler)
        //{
        //    _addWeatherForecastHandler = addWeatherForecastHandler;
        //    _getAllWeatherForecastHandler = getAllWeatherForecastHandler;
        //}

        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;
        public WeatherForecastController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var query = new GetAllWeatherForecast();
            return _queryDispatcher.Dispatch<GetAllWeatherForecast, IEnumerable<WeatherForecast>>(query);
        }

        [HttpPost]
        public void Add(AddWeatherForecast command)
        {
            _commandDispatcher.Dispatch(command);
        }

        [HttpGet("[action]")]
        public WeatherForecast? GetByYear()
        {
            return null;
        }
    }
}