namespace GrupaDotNet.CQRS.Meteorology
{
    public class WeatherForecastRepository
    {
        private readonly List<WeatherForecast> _forecasts = new();

        public IEnumerable<WeatherForecast> GetAll()
        {
            return _forecasts;
        }

        public void Add(WeatherForecast weatherForecast)
        {
            _forecasts.Add(weatherForecast);
        }
    }
}
