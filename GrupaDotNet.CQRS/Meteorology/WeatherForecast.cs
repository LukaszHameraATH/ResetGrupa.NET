namespace GrupaDotNet.CQRS.Meteorology
{
    public class WeatherForecast
    {
        public WeatherForecast(DateOnly date, int temperatureC, string? summary)
        {
            if (temperatureC < -273)
                throw new Exception($"Invalid temperature {temperatureC}");

            Date = date;
            TemperatureC = temperatureC;
            Summary = summary;
        }

        public DateOnly Date { get;  }

        public int TemperatureC { get;  }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; }
    }
}