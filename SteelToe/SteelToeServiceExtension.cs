using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SteelToe.Models;
using SteelToe.Services;

namespace SteelToe
{
    public static class SteelToeServiceExtension
    {
        public static IServiceCollection AddSteelToe(this IServiceCollection service, IConfiguration configuration)
        {
            if (service == null) throw new ArgumentNullException(nameof(service));
            service.Configure<Templates>(configuration.GetSection("Templates"))
                .AddHttpClient<IWeatherService,WeatherService>();
            return service;
        }
    }
}