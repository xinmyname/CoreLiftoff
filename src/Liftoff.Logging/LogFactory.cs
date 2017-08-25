using System.IO;
using System.Reflection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Liftoff.Config;
using System;

namespace Liftoff.Logging {

    public class LogFactory {

        public static class Defaults {
            public static Func<string> AppSettingsFilename = () => "appsettings.json";
            public static Func<string> CategoryName = () => "Default";
        }

        private readonly ILoggerFactory _loggerFactory;

        public LogFactory(IConfigurationRoot config) {
            
            _loggerFactory = new LoggerFactory();
            _loggerFactory.AddDefaultProviders(config);
        }

        public ILogger GetLogger(string categoryName = null) {
            return _loggerFactory.CreateLogger(categoryName ?? Defaults.CategoryName());
        }

        public static ILogger GetDefaultLogger() {

            string appSettingsFilename = Defaults.AppSettingsFilename();

            var config = new ConfigurationBuilder();

            if (File.Exists(appSettingsFilename))
                config.AddJsonFile(appSettingsFilename);

            config.AddCallingAssemblyAttributes(System.Reflection.Assembly.GetCallingAssembly());
            config.AddEnvironmentVariables();

            return new LogFactory(config.Build()).GetLogger();
        }
    }
}
