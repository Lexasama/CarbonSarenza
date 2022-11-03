using CarbonSarenza.Web.Domain.Entities;
using CarbonSarenza.Web.Domain.Repositories.Base;

namespace CarbonSarenza.Web.Domain.Repositories;

public interface ISettingRepository : IRepository<Setting>
{
    Task<Setting> FindLastEntry();
}