using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Net.Http.Headers;
using SteelToe.Models;
using CacheControlHeaderValue = System.Net.Http.Headers.CacheControlHeaderValue;

namespace SteelToe.Services
{
    public class WeatherService: IWeatherService
    {
        private readonly HttpClient _client;
        private readonly Templates _templates;

        public WeatherService(
            IOptionsSnapshot<Templates> templates, 
            HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            if (_client.DefaultRequestHeaders.CacheControl != null)
                _client.DefaultRequestHeaders.CacheControl.NoCache = true;
            
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