using Microsoft.AspNetCore.Mvc;
using Moq;
using Sarenza.Core.Entities;
using Sarenza.Core.Services;
using Sarenza.DAL.TemperatureCaptor;
using Sarenza.Web.Controllers;
using Sarenza.Web.Dto;
using Xunit;

namespace Sarenza.Tests;

public class TemperatureControllerTests
{
    private readonly Setting _defaultSetting = new()
    {
        ColdTemperature = 22,
        HotTemperature = 40,
        CreationDateTime = DateTime.Now,
        Id = 1
    };

    [Fact]
    public async Task GetTemperature_returns_a_ok_response()
    {
        var defaultSetting = _defaultSetting;
        var captor = new TemperatureCaptor();
        var sensorService = new Mock<ISensorService>();
        sensorService.Setup(s => s.GetSensorSetting()).ReturnsAsync(defaultSetting);
        var temperature = captor.GetTemperatureC();
        sensorService.Setup(s => s.GetTemperature()).ReturnsAsync(temperature).Verifiable();

        var historyService = new Mock<IHistoryService>();

        var sut = new TemperatureController(sensorService.Object, historyService.Object);

        var response = await sut.GetTemperature();

        var returnValue = Assert.IsType<OkObjectResult>(response.Result);

        var result = Assert.IsType<WeatherDto>(returnValue.Value);
        Assert.Equal(temperature, result.TemperatureC.Value);
        Assert.Equal("HOT", result.SensorState);
    }

    [Fact]
    public async Task GetState_returns_ok_with_the_correct_state()
    {
        var captor = new TemperatureCaptor();
        var temperature = captor.GetTemperatureC();

        var sensorService = new Mock<ISensorService>();

        sensorService.Setup(s => s.GetTemperature()).ReturnsAsync(temperature);
        var defaultSetting = _defaultSetting;
        sensorService.Setup(s => s.GetSensorSetting()).ReturnsAsync(defaultSetting);

        var historyService = new Mock<IHistoryService>();

        var sut = new TemperatureController(sensorService.Object, historyService.Object);

        var response = await sut.GetState();
        var returnValue = Assert.IsType<OkObjectResult>(response.Result);
        var result = Assert.IsType<StateDto>(returnValue.Value);

        var feeling = await sensorService.Object.GetState(temperature);

        Assert.Equal(result.Feeling, feeling.ToString());
    }

    [Fact]
    public async void can_get_last_15_history()
    {
        var sensorService = new Mock<ISensorService>();
        var historyService = new Mock<IHistoryService>();
        var historyData = new List<History>
        {
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new()
        };
        const int entries = 15;
        historyService.Setup(h => h.GetHistories(entries)).ReturnsAsync(historyData);
        var sut = new TemperatureController(sensorService.Object, historyService.Object);

        var response = await sut.GetHistory(entries);
        var returnValue = Assert.IsType<OkObjectResult>(response.Result);
        var result = Assert.IsAssignableFrom<IEnumerable<HistoryDto>>(returnValue.Value);

        Assert.Equal(historyData.Count, result.Count());
    }
}