using System.ComponentModel.DataAnnotations;

namespace Sarenza.Web.Dto;

public class SensorSettingUpdateDto
{
    [Required] public double HotTemperature { get; }

    [Required] public double ColdTemperature { get; }

    public SensorSettingUpdateDto(double hotTemperature, double coldTemperature)
    {
        HotTemperature = hotTemperature;
        ColdTemperature = coldTemperature;
    }
}