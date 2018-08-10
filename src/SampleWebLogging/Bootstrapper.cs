using System.IO;
using Liftoff.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Liftoff.Logging;
using Microsoft.Extensions.Configuration;

namespace SampleWebLogging
{
    public class Bootstrapper
    {
        public static void Main(string[] args)
        {
            var configBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var hostBuilder = WebHost.CreateDefaultBuilder(args)
                .UseConfiguration(configBuilder.Build())
                .ConfigureAppConfiguration(configure => { configure.AddLiftoffSources(); })
                .ConfigureLogging(configure => { configure.AddLiftoffProviders(); })
                .UseHttpSys()
                .UseStartup<Startup>();

            hostBuilder.Build().Run();
        }
    }
}
