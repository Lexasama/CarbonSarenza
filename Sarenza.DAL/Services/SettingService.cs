using Sarenza.Core.Entities;
using Sarenza.Core.Repositories;
using Sarenza.Core.Services;

namespace Sarenza.DAL.Services;

public class SettingService : ISettingService
{
    private readonly ISettingRepository _settingRepository;

    public SettingService(ISettingRepository settingRepository)
    {
        _settingRepository = settingRepository;
    }

    public async Task<Setting> FindSetting()
    {
        return await _settingRepository.FindLastEntry();
    }

    public async Task Update(double coldTemperature, double hotTemperature)
    {
        var setting = await _settingRepository.FindLastEntry();
        setting.ColdTemperature = coldTemperature;
        setting.HotTemperature = hotTemperature;
        await _settingRepository.UpdateAsync(setting);
    }
}