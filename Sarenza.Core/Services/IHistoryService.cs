using Sarenza.Core.Entities;

namespace Sarenza.Core.Services;

public interface IHistoryService
{
    public Task<IEnumerable<History>> GetHistories(int entriesNumber);
}