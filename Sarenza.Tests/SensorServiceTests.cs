using Moq;
using Sarenza.Core.Entities;
using Sarenza.Core.Repositories;
using Sarenza.DAL.Services;
using Sarenza.DAL.TemperatureCaptor;
using Sarenza.Entities;
using Xunit;

namespace Sarenza.Tests;

public class SensorServiceTests
{
    private readonly Setting _defaultSetting = new()
    {
        ColdTemperature = 22,
        HotTemperature = 40,
        CreationDateTime = DateTime.Now,
        Id = 1
    };

    [Theory]
    [InlineData(100.00, TemperatureFeeling.HOT)]
    [InlineData(15, TemperatureFeeling.COLD)]
    [InlineData(22, TemperatureFeeling.WARM)]
    [InlineData(40, TemperatureFeeling.HOT)]
    [InlineData(30, TemperatureFeeling.WARM)]
    public async Task GetState_returns_the_right_feeling(double temperature, TemperatureFeeling expectedFeeling)
    {
        var settingRepository = new Mock<ISettingRepository>();
        settingRepository.Setup(s => s.FindLastEntry()).ReturnsAsync(_defaultSetting);

        var temperatureCaptor = new Mock<ITemperatureCaptor>();
        var historyRepository = new Mock<ITemperatureHistoryRepository>();
        var sut = new SensorService(historyRepository.Object, settingRepository.Object, temperatureCaptor.Object);
        var feeling = await sut.GetState(temperature);
        Assert.Equal(expectedFeeling, feeling);
    }

    [Theory]
    [InlineData(100.00, TemperatureFeeling.HOT)]
    [InlineData(15, TemperatureFeeling.COLD)]
    [InlineData(22, TemperatureFeeling.WARM)]
    [InlineData(40, TemperatureFeeling.HOT)]
    [InlineData(30, TemperatureFeeling.WARM)]
    public async Task GetState_without_argument_returns_the_right_feeling(double temperature, TemperatureFeeling expectedFeeling)
    {
        var settingRepository = new Mock<ISettingRepository>();
        settingRepository.Setup(s => s.FindLastEntry()).ReturnsAsync(_defaultSetting);

        var temperatureCaptor = new Mock<ITemperatureCaptor>();
        temperatureCaptor.Setup(tc => tc.GetTemperatureC()).Returns(temperature).Verifiable();
        var historyRepository = new Mock<ITemperatureHistoryRepository>();
        var sut = new SensorService(historyRepository.Object, settingRepository.Object, temperatureCaptor.Object);
        var feeling = await sut.GetState();
        Assert.Equal(expectedFeeling, feeling);
        
        temperatureCaptor.Verify(tc => tc.GetTemperatureC(), Times.Once);
    }
}