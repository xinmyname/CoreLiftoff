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
            var services = new ServiceCollection()
                .AddConfiguration(configure => { configure.AddLiftoffSources(); })
                .AddLogging(configure => { configure.AddLiftoffProviders(); })
                .AddSingleton<Application>();

            using (var provider = services.BuildServiceProvider())
            {
                var app = provider.GetRequiredService<Application>();
                app.Run();
            }
        }
    }
}
