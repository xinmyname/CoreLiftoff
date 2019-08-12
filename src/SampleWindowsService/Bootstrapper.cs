using Liftoff.Config;
using Liftoff.Service;
using Liftoff.Logging;
using Microsoft.Extensions.DependencyInjection;
using SampleWindowsService.Infrastructure;

namespace SampleWindowsService
{
    class Bootstrapper
    {
        static void Main()
        {
            HostFactory.Run(x =>
            {
                var log = LogFactory.GetDefaultLogger();

                x.ConfigureLogging(log.Debug, log.Info, log.Warn, log.Error, log.Critical);

                x.Service<WinService>(s =>
                {
                    s.ConstructUsing(() =>
                    {
                        var services = new ServiceCollection()
                            .AddConfiguration(configure => { configure.AddLiftoffSources(); })
                            .AddLogging(configure => { configure.AddLiftoffProviders(); })
                            .AddSingleton<WinService>();

                        var provider = services.BuildServiceProvider();

                        return provider.GetRequiredService<WinService>();
                    });

                    s.WhenStarted(ws => { ws.Start(); });
                    s.WhenStopped(ws => { ws.Stop(); });
                });
            });
        }
    }
}
