namespace CarbonSarenza.Web.Domain.Entities;

public class Setting
{
    public int Id { get; set; }
    public double HotTemperature { get; set; }
    public double ColdTemperature { get; set; }
    public DateTime CreationDateTime { get; set; } = new DateTime();
}