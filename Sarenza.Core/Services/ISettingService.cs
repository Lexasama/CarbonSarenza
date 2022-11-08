using Sarenza.Core.Entities;

namespace Sarenza.Core.Services;

public interface ISettingService
{
    public Task<Setting> FindSetting();
    public Task Update(double coldTemp, double hotTemp);
}