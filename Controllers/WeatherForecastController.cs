using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace user_secret_dotnet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {       
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly WeatherClient _client;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WeatherClient client)
        {
            _logger = logger;
            _client = client;
        }

        [HttpGet]
        [Route("{city}")]
        public async Task<WeatherForecast> Get(string city)
        {
            var _forecast = await _client.GetCurrentWetherAsync(city);

            return new WeatherForecast{
                Summary = _forecast.weather[0].description,
                TemperatureC = (int)_forecast.main.temp,
                Date = DateTimeOffset.FromUnixTimeMilliseconds(_forecast.dt).DateTime
            };
        }
    }
}
