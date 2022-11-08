using Sarenza.Core.ValueObjects;
using Sarenza.Entities;

namespace Sarenza.Web.Dto;

public class WeatherDto
{
    public Celsius TemperatureC { get; }

    public string SensorState { get; }

    public WeatherDto(double celsius, TemperatureFeeling feeling)
    {
        TemperatureC = Celsius.From(celsius);
        SensorState = feeling.ToString();
    }
}