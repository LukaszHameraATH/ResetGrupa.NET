using GrupaDotNet.CQRS.Lib.Queries;

namespace GrupaDotNet.CQRS.Meteorology
{
    public record GetAllWeatherForecast() : IQuery<IEnumerable<WeatherForecast>>;
}
