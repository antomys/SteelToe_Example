using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SteelToe.Models;
using SteelToe.Services;

namespace SteelToe_Example.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = 
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IWeatherService _weatherService;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherService weatherService)
        {
            _logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetDefault()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }

        [HttpGet]
        public async Task<ActionResult> GetFromSettingsWeather()
        {
            var result = await _weatherService.GetSettingWeather();
            return Ok(result);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetFromSettingsSomethingElse([FromQuery] string cityName)
        {
            var result = await _weatherService.GetSettingRandomValue(cityName);
            return Ok(result);
        }
    }
}