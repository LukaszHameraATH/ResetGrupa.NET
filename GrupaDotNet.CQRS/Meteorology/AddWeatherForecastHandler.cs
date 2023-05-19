using GrupaDotNet.CQRS.Lib.Commands;

namespace GrupaDotNet.CQRS.Meteorology
{
    public class AddWeatherForecastHandler: ICommandHandler<AddWeatherForecast>
    {
        private readonly WeatherForecastRepository _repository;
        public AddWeatherForecastHandler(WeatherForecastRepository repository)
        {
            _repository = repository;
        }

        public void Handle(AddWeatherForecast command)
        {
            // walidacja ??
            var date = DateOnly.Parse(command.Date);
            var weatherForecast = new WeatherForecast(date, command.TemperatureC, command.Summary);
            _repository.Add(weatherForecast);
        }
    }
}
