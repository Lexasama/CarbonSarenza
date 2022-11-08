using Microsoft.AspNetCore.Mvc;
using Sarenza.Core.Services;
using Sarenza.Web.Dto;

namespace Sarenza.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class TemperatureController : ControllerBase
{
    private readonly ISensorService _sensorService;
    private readonly IHistoryService _historyService;

    public TemperatureController(ISensorService sensorService, IHistoryService historyService)
    {
        _sensorService = sensorService;
        _historyService = historyService;
    }

    [HttpGet(Name = "GetTemperature")]
    public async Task<ActionResult<WeatherDto>> GetTemperature()
    {
        var temperature = await _sensorService.GetTemperature();
        var feeling = await _sensorService.GetState();
        var response = new WeatherDto(temperature, feeling);
        return Ok(response);
    }

    [HttpGet("state", Name = "GetSensorState")]
    public async Task<ActionResult<StateDto>> GetState()
    {
        var response = StateDto.From(await _sensorService.GetState());
        return Ok(response);
    }

    [HttpGet("history/{entries:int}", Name = "GetHistory")]
    public async Task<ActionResult<IEnumerable<HistoryDto>>> GetHistory(int? entries)
    {
        var entriesNumber = 15;

        if (entries is not null) entriesNumber = entries.Value;
        var historys = await _historyService.GetHistories(entriesNumber);
        return Ok(HistoryDto.From(historys));
    }
}