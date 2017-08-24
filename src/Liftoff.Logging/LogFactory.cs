using System.IO;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Liftoff.Config;

namespace Liftoff.Logging {

    public class LogFactory {

        private readonly ILoggerFactory _loggerFactory;

        public LogFactory(IConfigurationRoot config) {
            
            _loggerFactory = new LoggerFactory();
            _loggerFactory.AddDefaultProviders(config);
        }

        public ILogger GetLogger(string categoryName = "Default") {
            return _loggerFactory.CreateLogger(categoryName);
        }

        public static ILogger GetDefaultLogger() {

            string appSettingsFilename = LogFactoryDefaults.AppSettingsFilename();

            var config = new ConfigurationBuilder();

            if (File.Exists(appSettingsFilename))
                config.AddJsonFile(appSettingsFilename);

            config.AddCallingAssemblyAttributes(System.Reflection.Assembly.GetCallingAssembly());
            config.AddEnvironmentVariables();

            return new LogFactory(config.Build()).GetLogger();
        }
    }
}
