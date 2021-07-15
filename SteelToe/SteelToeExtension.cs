using System;
using Microsoft.Extensions.Configuration;
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
                .ConfigureAppConfiguration((context, builder) =>
                {
                    var env = context.HostingEnvironment.EnvironmentName;
                    builder
                        .AddConfigServer(env)
                        .AddEnvironmentVariables();
                })
                .AddRefreshActuator();

            return provider;
        }
    }
}