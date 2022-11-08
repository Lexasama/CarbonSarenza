using System.Net;
using System.Net.Http.Json;
using Sarenza.Web.Dto;
using Xunit;

namespace Sarenza.Tests;

public class SettingControllerTests
{
    [Fact]
    public async Task can_get_and_update_sensor_setting()
    {
        using var client = ApiApplication.CreateClient(
        );

        using var response = await client.GetAsync("/setting");

        var responseBody = await response.Content.ReadFromJsonAsync<SettingDto>();

        Assert.NotNull(responseBody);
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        const double updatedHotTemp = 50;
        const double updatedColdTemp = 15;
        using var content = JsonContent.Create(new SensorSettingUpdateDto(updatedHotTemp, updatedColdTemp));
        using var putResponse = await client.PutAsync("/setting", content);

        Assert.Equal(HttpStatusCode.OK, putResponse.StatusCode);

        using var newResponse = await client.GetAsync("/setting");
        var newSetting = await newResponse.Content.ReadFromJsonAsync<SettingDto>();

        Assert.NotNull(newSetting);
        Assert.Equal(HttpStatusCode.OK, newResponse.StatusCode);

        Assert.Equal(updatedColdTemp, newSetting.ColdTemperature);
        Assert.Equal(updatedHotTemp, newSetting.HotTemperature);
    }
}