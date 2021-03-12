using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DottyLogs.Example.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly ILogger<ExampleController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public ExampleController(ILogger<ExampleController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("delay")]
        public async Task Delay()
        {
            _logger.LogInformation("Starting delay");
            await Task.Delay(5000);
            _logger.LogInformation("Finished delay");
        }

        [HttpGet("weather")]
        [HttpGet("backendweather")]
        public async Task<IActionResult> BackendWeather()
        {
            _logger.LogInformation("Starting call to backend service");
            var client = _httpClientFactory.CreateClient("backend");     
            var apiClient = new BackendApi.BackendApiClient(client.BaseAddress.ToString(), client);
            var weatherTask = apiClient.WeatherForecastAsync();
            var weather2Task = apiClient.WeatherForecastAsync();
            await Task.WhenAll(weatherTask, weather2Task);
            var weather = weatherTask.Result;
            var weather2 = weather2Task.Result;
            _logger.LogInformation($"Weather on {weather.First().Date} is {weather.First().TemperatureC}C. Now doing wait for 2s");
            await Task.Delay(2000);
            var weather3 = await apiClient.WeatherForecastAsync();
            _logger.LogInformation("Finished call to backend service");

            return Ok(weather3);
        }
    }
}
