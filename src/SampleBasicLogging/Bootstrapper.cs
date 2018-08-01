using Liftoff.Config;
using Liftoff.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SampleBasicLogging
{
    static class Bootstrapper
    {
        static void Main()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddLiftoffSources();

            var config = configBuilder.Build();

            var services = new ServiceCollection()
                .AddLogging(configure => { configure.AddLiftoffProviders(config); })
                .AddSingleton<Application>();

            using (var provider = services.BuildServiceProvider())
            {
                var app = provider.GetRequiredService<Application>();
                app.Run();
            }
        }
    }
}
