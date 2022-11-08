using Sarenza.Core.Entities;
using Sarenza.Core.Repositories.Base;

namespace Sarenza.Core.Repositories;

public interface ITemperatureHistoryRepository : IRepository<History>
{
    Task<IReadOnlyList<History>> FindLastEntries(int entriesNumber);
}