using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace xUnitApiTests.IntegrationTests
{

    public class WeatherforecastControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        readonly HttpClient _client;

        public WeatherforecastControllerTests(WebApplicationFactory<Program> application)
        {
            _client = application.CreateClient();
        }

        [Fact]
        public async Task GET_retrieves_weather_forecast()
        {
            var response = await _client.GetAsync("/weatherforecast/GetWeatherForecast");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        }

        [Fact]
        public async Task GET_retrieves_weather_bad()
        {
            var response = await _client.GetAsync("/weatherforecast/GetWeatherForecastBad");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }
    }


}
