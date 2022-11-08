using Sarenza.Core.Entities;

namespace Sarenza.Web.Dto;

public class SettingDto
{
    public int Id { get; set; }
    public double HotTemperature { get; set; }
    public double ColdTemperature { get; set; }
    public DateTime CreationDateTime { get; set; }

    public SettingDto()
    {
    }

    public SettingDto(int id, double hotTemperature, double coldTemperature, DateTime creationDateTime)
    {
        Id = id;
        HotTemperature = hotTemperature;
        ColdTemperature = coldTemperature;
        CreationDateTime = creationDateTime;
    }

    public static SettingDto From(Setting setting)
    {
        return new SettingDto(setting.Id, setting.HotTemperature, setting.ColdTemperature, setting.CreationDateTime);
    }
}