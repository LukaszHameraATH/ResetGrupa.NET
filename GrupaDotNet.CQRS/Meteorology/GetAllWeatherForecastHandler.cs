using GrupaDotNet.CQRS.Lib.Queries;

namespace GrupaDotNet.CQRS.Meteorology
{
    public class GetAllWeatherForecastHandler: IQueryHandler<GetAllWeatherForecast, IEnumerable<WeatherForecast>>
    {
        private readonly WeatherForecastRepository _repository;
        public GetAllWeatherForecastHandler(WeatherForecastRepository repository)
        {
            _repository = repository;
        }

        // WeatherForecastDTO!!
        public IEnumerable<WeatherForecast> Handle(GetAllWeatherForecast query)
        {
            return _repository.GetAll();
        }
    }
}
