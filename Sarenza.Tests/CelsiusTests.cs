using Sarenza.Core.ValueObjects;
using Xunit;

namespace Sarenza.Tests;

public class CelsiusTests
{
    [Fact]
    public void temperature_below_AbsoluteZeroInCelsius_throws_TemperatureBelowAbsoluteZeroException()
    {
        Assert.Throws<TemperatureBelowAbsoluteZeroException>(() => Celsius.From(-500));
    }
}