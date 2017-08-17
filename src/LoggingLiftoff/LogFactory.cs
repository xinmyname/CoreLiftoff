using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace LoggingLiftoff {

    public class LogFactory {

        private readonly ILoggerFactory _loggerFactory;

        public LogFactory(IConfigurationRoot config) {
            _loggerFactory = new LoggerFactory();
            _loggerFactory.AddDefaultProviders(config);
        }

        public ILogger GetLogger() {
            _loggerFactory.CreateLogger()
        }

        public static ILogger GetDefaultLogger() {

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            return new LogFactory(config).GetLogger();
        }
    }

    public class LogFactoryDefaults {
        
    }
}
