using Sarenza.Core.Entities;
using Sarenza.Core.Repositories.Base;

namespace Sarenza.Core.Repositories;

public interface ISettingRepository : IRepository<Setting>
{
    public Task<Setting> FindLastEntry();
    public Task UpdateAsync(Setting setting);
}