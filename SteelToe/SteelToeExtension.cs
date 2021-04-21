using System;
using Microsoft.Extensions.Hosting;
using Steeltoe.Extensions.Configuration.ConfigServer;
using Steeltoe.Management.Endpoint;

namespace SteelToe
{
    public static class SteelToeExtension
    {
        public static IHostBuilder AddSteelToe(this IHostBuilder provider)
        {
            if (provider == null) throw new ArgumentNullException(nameof(provider));

            provider
                .AddRefreshActuator()
                .AddConfigServer();

            return provider;
        }
    }
}