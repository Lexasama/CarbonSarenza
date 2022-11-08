using Sarenza.Core.Entities;
using Sarenza.Entities;

namespace Sarenza.Core.Services;

public interface ISensorService
{
    Task<double> GetTemperature();
    Task<TemperatureFeeling> GetState();
    Task<TemperatureFeeling> GetState(double temperature);
    Task<Setting> GetSensorSetting();
}