using Moq;
using Sarenza.Core.Entities;
using Sarenza.Core.Repositories;
using Sarenza.DAL.Services;
using Xunit;

namespace Sarenza.Tests;

public class HistoryServiceTest
{
    [Fact]
    public async Task GetHistory_returns_the_right_history_list()
    {

        var historyRepository = new Mock<ITemperatureHistoryRepository>();
        var data = new List<History>()
        {
            new(),
            new(),
            new(),
            new(),
            new(),
            new()
        };
        const int entriesNumber = 1;
        historyRepository.Setup(hr => hr.FindLastEntries(entriesNumber)).ReturnsAsync(data.GetRange(0,entriesNumber));
        var sut = new HistoryService(historyRepository.Object);
        var histories = await sut.GetHistories(1);
        Assert.Single(histories);
        historyRepository.Verify(hr => hr.FindLastEntries(entriesNumber), Times.Once);
    }
}