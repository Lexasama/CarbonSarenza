using Microsoft.AspNetCore.Mvc;
using Sarenza.Core.Services;
using Sarenza.Web.Dto;

namespace Sarenza.Web.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class SettingController : ControllerBase
{
    private readonly ISettingService _service;

    public SettingController(ISettingService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<SettingDto>> GetSetting()
    {
        var setting = await _service.FindSetting();
        return Ok(SettingDto.From(setting));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateSensorSettings([FromBody] SensorSettingUpdateDto dto)
    {
        await _service.Update(dto.ColdTemperature, dto.HotTemperature);
        return Ok();
    }
}