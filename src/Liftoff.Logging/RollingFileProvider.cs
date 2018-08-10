using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Liftoff.Logging
{
    public class RollingFileProvider : ILoggerProvider
    {
        private readonly Lazy<ILogger> _lazyLogger;

        public RollingFileProvider(IConfiguration config)
        {
            _lazyLogger = new Lazy<ILogger>(() =>
            {
                string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

                if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Library/Logs";

                string companyName = config["assembly:company"];
                string productName = config["assembly:product"];
                string appName = config["assembly:name"];

                string logFilePath = Path.Combine(appDataFolder, companyName);
                logFilePath = Path.Combine(logFilePath, productName);
                logFilePath = Path.Combine(logFilePath, "log");
                logFilePath = Path.Combine(logFilePath, $"{appName}.log");

                var options = new RollingFileOptions
                {
                    LogFilePath = logFilePath,
                    MaximumAgeInDays = 30
                };

                return new RollingFileLogger(DefaultTimeKeeper.Instance, DefaultFileManager.Instance, options);
            });
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _lazyLogger.Value;
        }

        public void Dispose()
        {
            var logger = _lazyLogger.Value as RollingFileLogger;
            logger?.Dispose();
        }
    }
}
