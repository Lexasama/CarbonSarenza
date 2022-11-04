using CarbonSarenza.Web.Domain.Entities;
using CarbonSarenza.Web.Domain.Repositories;
using CarbonSarenza.Web.Domain.Services;

namespace CarbonSarenza.Web.Infrastructure.Services
{
    public class SensorService :  ISensorService
    {
        private readonly ITemperatureHistoryRepository _temperatureHistoryRepository;
        private readonly ISettingRepository _settingRepository;

        public SensorService(ITemperatureHistoryRepository temperatureHistoryRepository, ISettingRepository settingRepository)
        {
            _temperatureHistoryRepository = temperatureHistoryRepository;
            _settingRepository = settingRepository;
        }


        public async Task<double> GetTemperature()
        {
            return await _temperatureHistoryRepository.FindLastEntry();
        }

        public async Task<IEnumerable<double>> GetHistory(int entriesNumber = 15)
        {

            return await _temperatureHistoryRepository.FindLastEntries(entriesNumber);
        }

        public Task<Setting> UpdateSettings(double coldTemperature, double hotTemperature)
        {
            //delete or findfiirst existing one and save new one
            throw new NotImplementedException();
        }

        public async Task UpdateTemperatureSensorState()
        {
            //getState and saveState
            throw new NotImplementedException();
        }

        public async Task<string> GetState()
        {
            var currentTemperate = await GetTemperature();

            var settings = await GetSensorSetting();

            if (currentTemperate >= settings.HotTemperature)
            {
                return SensorState.HOT.ToString();
            }
            if (currentTemperate < settings.ColdTemperature)
            {
                return SensorState.COLD.ToString();
            }

            return SensorState.WARM.ToString();

        }

        public async Task<Setting> GetSensorSetting()
        {
            return await _settingRepository.FindLastEntry();
        }
    }
}
