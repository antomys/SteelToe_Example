using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SteelToe.Models;

namespace SteelToe.Services
{
    public class WeatherService: IWeatherService
    {
        private readonly HttpClient _client;
        private readonly ILogger<WeatherService> _logger;
        private readonly Templates _templates;

        public WeatherService(
            HttpClient client, 
            IOptionsSnapshot<Templates> templates,
            ILogger<WeatherService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger;
            _templates = templates.Value ?? throw new ArgumentNullException(nameof(templates));
        }

        public async Task<string> GetSettingWeather()
        {
            return await _client.GetStringAsync(_templates.Weather);
        }

        public async Task<string> GetSettingRandomValue(string cityName)
        {
            var link = _templates.SomethingElse.Replace("__PASTE__", cityName);
            var data = await _client.GetStringAsync(new Uri(link));

            return data;
        }
    }
}