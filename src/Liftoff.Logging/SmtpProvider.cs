using System;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Liftoff.Logging {
    
    public class SmtpProvider : ILoggerProvider {

        private readonly IConfigurationRoot _config;

        public SmtpProvider(IConfigurationRoot config) {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName) {

            string productName = _config["assembly:product"];
            string appName = _config["assembly:name"];
            
            string source = (productName == appName)
                ? productName
                : $"{productName} - {appName}";

            var options = new SmtpOptions {
                ComputerName = Environment.MachineName,
                Host = _config["mail:host"],
                From = _config["mail:from"],
                Recipients = _config["criticalErrorRecipient"].Split(';',','),
                UserName = _config["mail:username"],
                Password = _config["mail:password"],
                Source = source
            };

            return new SmtpLogger(new SmtpClient(), options);
        }

        public void Dispose() {
        }
    }
}
