using Liftoff.Config;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Liftoff.Logging
{
    public class LogFactory
    {
        private readonly ILoggerFactory _loggerFactory;

        public LogFactory(IConfigurationRoot config)
        {
            _loggerFactory = new LoggerFactory();
            _loggerFactory.AddLiftoffProviders(config);
        }

        public ILogger GetLogger(string categoryName = "Default")
        {
            return _loggerFactory.CreateLogger(categoryName);
        }

        public static ILogger GetDefaultLogger()
        {
            var config = new ConfigurationBuilder()
                .AddLiftoffSources();

            return new LogFactory(config.Build()).GetLogger();
        }
    }
}
