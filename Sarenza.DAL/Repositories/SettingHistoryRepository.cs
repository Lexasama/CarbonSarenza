using Microsoft.EntityFrameworkCore;
using Sarenza.Core.Entities;
using Sarenza.Core.Repositories;
using Sarenza.DAL.Data;
using Sarenza.DAL.Repositories.Base;

namespace Sarenza.DAL.Repositories;

public class SettingHistoryRepository : Repository<Setting>, ISettingRepository
{
    public SettingHistoryRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<Setting> FindLastEntry()
    {
        return (await _dbContext.Settings
            .OrderByDescending(s => s.CreationDateTime).Take(1)
            .ToListAsync()).First();
    }

    public async Task UpdateAsync(Setting setting)
    {
        _dbContext.Settings.Update(setting);
        await _dbContext.SaveChangesAsync();
    }
}