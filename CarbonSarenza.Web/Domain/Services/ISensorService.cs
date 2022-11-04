using CarbonSarenza.Web.Domain.Entities;

namespace CarbonSarenza.Web.Domain.Services
{
    public interface ISensorService
    {
        Task<double> GetTemperature();

        Task<IEnumerable<double>> GetHistory(int entriesNumber);

        Task<string> GetState();

        Task<Setting> GetSensorSetting();

        Task<Setting> UpdateSettings(double coldTemp, double hotTemp);
    }
}
