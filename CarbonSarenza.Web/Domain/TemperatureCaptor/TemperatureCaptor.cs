namespace CarbonSarenza.Web.Domain.TemperatureCaptor;

public class TemperatureCaptor : ITemperatureCaptor
{

    private readonly Random _random = new Random();
    private const double MAX = 100.00;
    private const double MIN = -30.0;
    public TemperatureCaptor()
    {
        
    }
    public double GetTemperature()
    {
        return _random.NextDouble() * (MAX - MIN) + MIN;
    }
}