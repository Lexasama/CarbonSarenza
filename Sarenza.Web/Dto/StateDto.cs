using Sarenza.Entities;

namespace Sarenza.Web.Dto;

public class StateDto
{
    public string Feeling { get; }

    private StateDto(string feeling)
    {
        Feeling = feeling;
    }

    public static StateDto From(TemperatureFeeling temperatureFeeling)
    {
        return new StateDto(temperatureFeeling.ToString());
    }
}