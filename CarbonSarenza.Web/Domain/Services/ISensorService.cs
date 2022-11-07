using CarbonSarenza.Web.Domain.Entities;
using CarbonSarenza.Web.Domain.ValueObjects;

namespace CarbonSarenza.Web.Domain.Services
{
    public interface ISensorService
    {
        Task<double> GetTemperature();
        
        Task<IEnumerable<double>> GetHistory(int entriesNumber);

        Task<TemperatureFeeling> GetState();

        Task<Setting> UpdateSettings(double coldTemp, double hotTemp);
    }
}
