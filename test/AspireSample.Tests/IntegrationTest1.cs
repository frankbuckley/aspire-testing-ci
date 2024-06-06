using System.Net;

namespace AspireSample.Tests;

[Collection("DistributedApplicationFixture")]
public class IntegrationTest1(
    DistributedApplicationFixture<Projects.AspireSample_AppHost> appFixture)
{
    [Fact]
    public async Task GetWebResourceRootReturnsOkStatusCode()
    {
        // Act
        var httpClient = appFixture.App.CreateHttpClient("webfrontend");
        var response = await httpClient.GetAsync("/");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetWebResourceWeatherReturnsOkStatusCode()
    {
        // Act
        var httpClient = appFixture.App.CreateHttpClient("webfrontend");
        var response = await httpClient.GetAsync("/weather");

        // Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
    }
}
