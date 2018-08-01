using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Liftoff.Config
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, Action<IConfigurationBuilder> configure)
        {
            var configBuilder = new ConfigurationBuilder();
            services.AddSingleton<IConfigurationBuilder>(configBuilder);

            configure(configBuilder);

            services.AddSingleton<IConfiguration>(configBuilder.Build());

            return services;
        }
    }
}