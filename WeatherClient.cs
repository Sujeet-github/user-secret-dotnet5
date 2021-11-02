using System.Net.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace user_secret_dotnet5
{
    public class WeatherClient
    {
        private readonly HttpClient _client;
        private readonly ServiceSettings _settings;
        public WeatherClient(HttpClient client, IOptions<ServiceSettings> Settings)
        {
            this._client = client;
            _settings = Settings.Value;
        }

        public record Weather(string description);
        public record Main(decimal temp);
        public record Forecast(Weather[] weather, Main main, long dt);

        public async Task<Forecast> GetCurrentWetherAsync(string _city)
        {
            var _forcast = await _client.GetFromJsonAsync<Forecast>($"https://{_settings.HostName}/data/2.5/weather?q={_city}&appid={_settings.ApiKey}&units=metric");
            return _forcast;
        }
    }
}