using Liftoff.Config;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Liftoff.Logging;

namespace SampleWebLogging
{
    public class Bootstrapper
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(configure => { configure.AddLiftoffSources(); })
                .ConfigureLogging(configure => { configure.AddLiftoffProviders(); })
                .UseStartup<Startup>();
    }
}
