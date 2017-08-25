using System;
using System.IO;
using System.Runtime.InteropServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Liftoff.Logging
{
    public class RollingFileProvider : ILoggerProvider {

        private readonly IConfigurationRoot _config;

        public RollingFileProvider(IConfigurationRoot config) {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName) {

            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/Library/Logs";

            string companyName = _config["assembly:company"];
            string productName = _config["assembly:product"];
            string appName = _config["assembly:name"];
            
            string logFilePath = Path.Combine(appDataFolder, companyName);
            logFilePath = Path.Combine(logFilePath, productName);
            logFilePath = Path.Combine(logFilePath, $"{appName}.log");

            var options = new RollingFileOptions {
                LogFilePath = logFilePath,
                MaximumAgeInDays = 30
            };

            return new RollingFileLogger(DefaultTimeKeeper.Instance, DefaultFileManager.Instance, options);
        }

        public void Dispose() {
        }
    }
}
