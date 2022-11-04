namespace CarbonSarenza.Web.Domain.Entities;

public class History : BaseEntity<int>
{
    public DateTime Date { get; init; } = DateTime.Now;
    public  double Temperature { get; init; }
}