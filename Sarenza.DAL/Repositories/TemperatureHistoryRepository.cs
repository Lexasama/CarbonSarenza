using Microsoft.EntityFrameworkCore;
using Sarenza.Core.Entities;
using Sarenza.Core.Repositories;
using Sarenza.DAL.Data;
using Sarenza.DAL.Repositories.Base;

namespace Sarenza.DAL.Repositories;

public class TemperatureHistoryRepository : Repository<History>, ITemperatureHistoryRepository
{
    public TemperatureHistoryRepository(DatabaseContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<History>> FindLastEntries(int entriesNumber)
    {
        return (await _dbContext.History
            .OrderByDescending(h => h.Date)
            .Take(entriesNumber)
            .ToListAsync()).AsReadOnly();
    }
}