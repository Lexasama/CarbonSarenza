using Sarenza.Core.Entities;
using Sarenza.Core.Repositories;
using Sarenza.Core.Services;

namespace Sarenza.DAL.Services;

public class HistoryService : IHistoryService
{
    private readonly ITemperatureHistoryRepository _historyRepository;

    public HistoryService(ITemperatureHistoryRepository historyService)
    {
        _historyRepository = historyService;
    }

    public async Task<IEnumerable<History>> GetHistories(int entriesNumber)
    {   
        return await _historyRepository.FindLastEntries(entriesNumber);
    }
}