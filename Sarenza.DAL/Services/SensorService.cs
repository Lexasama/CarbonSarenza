using Sarenza.Core.Entities;
using Sarenza.Core.Repositories;
using Sarenza.Core.Services;
using Sarenza.DAL.TemperatureCaptor;
using Sarenza.Entities;

namespace Sarenza.DAL.Services;

public class SensorService : ISensorService
{
    private readonly ITemperatureHistoryRepository _temperatureHistoryRepository;
    private readonly ISettingRepository _settingRepository;
    private readonly ITemperatureCaptor _captor;

    public SensorService(ITemperatureHistoryRepository temperatureHistoryRepository,
        ISettingRepository settingRepository, ITemperatureCaptor captor)
    {
        _temperatureHistoryRepository = temperatureHistoryRepository;
        _settingRepository = settingRepository;
        _captor = captor;
    }

    public async Task<double> GetTemperature()
    {
        var currentTemperature = _captor.GetTemperatureC();
        await _temperatureHistoryRepository.AddAsync(new History()
        {
            TemperatureC = currentTemperature
        });

        return currentTemperature;
    }


    public async Task<TemperatureFeeling> GetState(double temperature)
    {
        var settings = await GetSensorSetting();

        if (temperature >= settings.HotTemperature) return TemperatureFeeling.HOT;
        if (temperature < settings.ColdTemperature) return TemperatureFeeling.COLD;

        return TemperatureFeeling.WARM;
    }

    public async Task<TemperatureFeeling> GetState()
    {
        var temperature = await GetTemperature();
        return await GetState(temperature);
    }

    public async Task<Setting> GetSensorSetting()
    {
        return await _settingRepository.FindLastEntry();
    }
}