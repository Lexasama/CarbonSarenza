using CarbonSarenza.Web.Domain.ValueObjects;

namespace CarbonSarenza.Web.Dto
{
    public class WeatherDto
    {
        public Celsius TemperatureC { get; }

        public string SensorState { get; }

        public WeatherDto(Celsius temperatureC, TemperatureFeeling sensorState)
        {
            TemperatureC = temperatureC;
            SensorState = sensorState.ToString();
        }
    }
}
