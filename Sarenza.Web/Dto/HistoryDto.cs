using Sarenza.Core.Entities;

namespace Sarenza.Web.Dto;

public class HistoryDto
{
    public int Id { get; }
    public DateTime Date { get; }
    public double TemperatureC { get; }

    public HistoryDto(int id, DateTime date, double temperatureC)
    {
        Id = id;
        Date = date;
        TemperatureC = temperatureC;
    }

    public static HistoryDto From(History history)
    {
        return new HistoryDto(history.Id, history.Date, history.TemperatureC);
    }

    public static IEnumerable<HistoryDto> From(IEnumerable<History> histories)
    {
        return histories.Select(From).ToList();
    }
}