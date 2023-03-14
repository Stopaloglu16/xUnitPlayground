using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;

namespace xUnitApiTests
{

    public class PersonControllerTests : IClassFixture<WebApplicationFactory<Program>>
    {
        readonly HttpClient _client;

        public PersonControllerTests(WebApplicationFactory<Program> application)
        {
            _client = application.CreateClient();
        }

        [Fact]
        public async Task GET_retrieves_weather_forecast()
        {
            var response = await _client.GetAsync("/weatherforecast/GetWeatherForecast");
            Assert.Equal(response.StatusCode, HttpStatusCode.OK);

        }

        [Fact]
        public async Task GET_retrieves_weather_bad()
        {
            var response = await _client.GetAsync("/weatherforecast/GetWeatherForecastBad");
            Assert.Equal(response.StatusCode, HttpStatusCode.BadRequest);

        }
    }


}
