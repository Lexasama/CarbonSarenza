using Moq;
using Sarenza.Core.Entities;
using Sarenza.Core.Repositories;
using Sarenza.DAL.Services;
using Xunit;

namespace Sarenza.Tests;

public class SettingServiceTests
{
    [Fact]
    public async Task FindSetting_returns_settings()
    {
        Setting defaultSetting = new()
        {
            ColdTemperature = 22,
            HotTemperature = 40,
            CreationDateTime = DateTime.Now,
            Id = 1
        };
        var settingRepository = new Mock<ISettingRepository>();

        settingRepository.Setup(s => s.FindLastEntry()).ReturnsAsync(defaultSetting).Verifiable();
        var sut = new SettingService(settingRepository.Object);

        var setting = await sut.FindSetting();
        
        Assert.Equal(defaultSetting, setting);
        settingRepository.Verify(s => s.FindLastEntry(), Times.Once);
    }
}