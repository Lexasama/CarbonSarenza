using CarbonSarenza.Web.Domain.Data;
using CarbonSarenza.Web.Domain.Entities;
using CarbonSarenza.Web.Domain.Repositories;
using CarbonSarenza.Web.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CarbonSarenza.Web.Infrastructure.Repositories;

public class SettingHistoryRepository :  Repository<Setting>, ISettingRepository
{
    public SettingHistoryRepository(DatabaseContext context) : base(context)
    {
    }


    public async Task<Setting> FindLastEntry()
    {
        return (await _dbContext.Settings
                .OrderByDescending(s => s.CreationDateTime)
                .Take(1)
                .ToListAsync())
            .First();
    }
}