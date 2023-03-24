using GrupaDotNet.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GrupaDotNet.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ITest _test;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ITest test)
        {
            _logger = logger;
            _test = test;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get(int a)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            _test.Test();
        }
    }
}