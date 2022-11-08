namespace Sarenza.DAL.TemperatureCaptor;

public class TemperatureCaptor : ITemperatureCaptor
{
    private readonly Random _random = new();
    private const double MAX = 100.00;
    private const double MIN = -30.0;

    public double GetTemperatureC()
    {
        return _random.NextDouble() * (MAX - MIN) + MIN;
    }
}