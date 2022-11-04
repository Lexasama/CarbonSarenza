using CarbonSarenza.Web.Domain.Services;
using CarbonSarenza.Web.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarbonSarenza.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TemperatureController : ControllerBase
    {

        private readonly ISensorService _services;


        public TemperatureController(ISensorService sensorService)
        {
            _services = sensorService;  
        }

        [HttpGet(Name = "GetTemperature")]
        public async Task<ActionResult<double>> Get()
        {
            return Ok(await _services.GetTemperature());
        }

        [HttpGet("state", Name ="GetSensorState")]
        public async Task<ActionResult<string>> GetState()
        {
            return Ok(await _services.GetState());
        }

        [HttpGet("history/{entries:int}", Name ="GetHistory")]
        public async Task<ActionResult<IEnumerable<double>>> GetHistory(int? entries)
        {
            var entriesNumber = 15;

            if (entries is not null)
            {
                entriesNumber = entries.Value;
            }
            return Ok(await _services.GetHistory(entriesNumber));
        }

        [HttpPut("settings")]
        public async Task<IActionResult> UpdateSensorSettings([FromBody] SensorSettingUpdateDto dto)
        {
            return Ok(await _services.UpdateSettings(dto.ColdTemperature, dto.HotTemperature));
        }


    }
}
