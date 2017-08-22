using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Liftoff.Logging
{
    public static class LoggerFactoryExtensions {

        public static ILoggerFactory AddDefaultProviders(this ILoggerFactory loggerFactory, IConfigurationRoot config) {

            loggerFactory.AddProvider(new ConsoleLoggerProvider());
            loggerFactory.AddProvider(new RollingFileProvider(config));

            return loggerFactory;
        }
    }
}
