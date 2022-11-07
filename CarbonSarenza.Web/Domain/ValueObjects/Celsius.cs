namespace CarbonSarenza.Web.Domain.ValueObjects;
using ValueOf;
public class Celsius : ValueOf<double, Celsius>
{
    private const double  AbsoluteZeroInCelsius = -273.15;
        
        
    protected override void Validate()
    {
        if (Value < AbsoluteZeroInCelsius)
        {
            throw new TemperatureBelowAbsoluteZeroException(Value);
        }
    }
    
}

public class TemperatureBelowAbsoluteZeroException : Exception
{
    public TemperatureBelowAbsoluteZeroException(double temperature): base($"Temperature can not be below absolute zero. Current value: {temperature}")
    {
        
    }
}