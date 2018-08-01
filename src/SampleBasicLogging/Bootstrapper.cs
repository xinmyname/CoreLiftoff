using System;
using Liftoff.Config;
using Liftoff.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleBasicLogging {

    class Bootstrapper {

        static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddLiftoffSources();

            var config = configBuilder.Build();

            var services = new ServiceCollection()
                .AddLogging(configure => { configure.AddLiftoffProviders(config); })
                .AddSingleton<Application>();

            foreach (var service in services)
                Console.WriteLine($"{service.ServiceType} --> {service.ImplementationType}");
            
            using (var provider = services.BuildServiceProvider())
            {
                var app = provider.GetRequiredService<Application>();
                app.Run();
            }            
        }
    }
}
