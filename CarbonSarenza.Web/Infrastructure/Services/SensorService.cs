using CarbonSarenza.Web.Domain.Entities;
using CarbonSarenza.Web.Domain.Repositories;
using CarbonSarenza.Web.Domain.Services;
using CarbonSarenza.Web.Domain.TemperatureCaptor;

namespace CarbonSarenza.Web.Infrastructure.Services
{
    public class SensorService :  ISensorService
    {
        private readonly ITemperatureHistoryRepository _temperatureHistoryRepository;
        private readonly ISettingRepository _settingRepository;
        private readonly ITemperatureCaptor _captor;

        public SensorService(ITemperatureHistoryRepository temperatureHistoryRepository, ISettingRepository settingRepository, ITemperatureCaptor captor)
        {
            _temperatureHistoryRepository = temperatureHistoryRepository;
            _settingRepository = settingRepository;
            _captor = captor;
        }


        public async Task<double> GetTemperature()
        {
            double currentTemperature = _captor.GetTemperature();
            await _temperatureHistoryRepository.AddAsync(new History()
            {
               TemperatureC = currentTemperature
            });
            
            return currentTemperature;
        }

        public async Task<IEnumerable<double>> GetHistory(int entriesNumber = 15)
        {
            return await _temperatureHistoryRepository.FindLastEntries(entriesNumber);
        }

        public async Task<Setting> UpdateSettings(double coldTemperature, double hotTemperature)
        {
            var setting = await _settingRepository.FindLastEntry();
            setting.ColdTemperature = coldTemperature;
            setting.HotTemperature = hotTemperature;
            return await _settingRepository.AddAsync(setting);
        }

        public async Task UpdateTemperatureSensorState()
        {
            //getState and saveState
            throw new NotImplementedException();
        }

        public async Task<TemperatureFeeling> GetState()
        {
            var currentTemperate = await GetTemperature();

            var settings = await GetSensorSetting();

            if (currentTemperate >= settings.HotTemperature)
            {
                return TemperatureFeeling.HOT;
            }
            if (currentTemperate < settings.ColdTemperature)
            {
                return TemperatureFeeling.COLD;
            }

            return TemperatureFeeling.WARM;

        }

        private async Task<Setting> GetSensorSetting()
        {
            return await _settingRepository.FindLastEntry();
        }
    }
}
