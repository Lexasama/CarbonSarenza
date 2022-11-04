
using CarbonSarenza.Web.Domain.Data;
using CarbonSarenza.Web.Domain.Entities;
using CarbonSarenza.Web.Domain.Repositories;
using CarbonSarenza.Web.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;


namespace CarbonSarenza.Web.Infrastructure.Repositories;

public class TemperatureHistoryRepository : Repository<History>, ITemperatureHistoryRepository
{
 

    public TemperatureHistoryRepository(DatabaseContext context) : base(context)
    {
    }
    
    public async Task<IReadOnlyList<double>> FindLastEntries(int entriesNumber)
    {
        return (await _dbContext.History
            .OrderByDescending(h => h.Date)
            .Take(entriesNumber)
            .Select(h => h.Temperature)
            .ToListAsync()).AsReadOnly();
    }

    public async Task<double> FindLastEntry()
    {
        return (await FindLastEntries(1)).FirstOrDefault();
    }
}