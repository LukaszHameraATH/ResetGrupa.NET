using GrupaDotNet.CQRS.Lib.Commands;

namespace GrupaDotNet.CQRS.Meteorology
{
    public record AddWeatherForecast(string Date, int TemperatureC, string? Summary) : ICommand;
}
