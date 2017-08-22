using System.IO;
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

            string appDataFolder = _config["ALLUSERSPROFILE"];
            string companyName = _config["Assembly:Company"] ?? "Company";
            string productName = _config["Assembly:Product"] ?? "Product";
            string appName = _config["Assembly:Name"] ?? "App";
            
            string logFilePath = Path.Combine(appDataFolder, companyName);
            logFilePath = Path.Combine(logFilePath, productName);
            logFilePath = Path.Combine(logFilePath, $"{appName}.log");

            var options = new RollingFileOptions {
                LogFilePath = logFilePath,
                MaximumAgeInDays = 30
            };

            return new RollingFileLogger(DefaultTimeKeeper.Instance, DefaultFileManager.Instance, options);
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose() {
        }
    }
}
