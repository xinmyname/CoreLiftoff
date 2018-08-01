using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Liftoff.Logging
{
    public class SmtpProvider : ILoggerProvider
    {
        private readonly IConfiguration _config;

        public SmtpProvider(IConfiguration config)
        {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName)
        {
            string productName = _config["assembly:product"];
            string appName = _config["assembly:name"];

            string source = (productName == appName)
                ? productName
                : $"{productName} - {appName}";

            string criticalErrorRecipient = _config["criticalErrorRecipient"] ?? String.Empty;

            var options = new SmtpOptions
            {
                ComputerName = Environment.MachineName,
                Host = _config["mail:host"],
                From = _config["mail:from"],
                Recipients = criticalErrorRecipient.Split(';', ','),
                UserName = _config["mail:username"],
                Password = _config["mail:password"],
                UseDefaultCredentials = false,
                Source = source
            };

            return new SmtpLogger(new EmailSender(options), options);
        }

        public void Dispose()
        {
        }
    }
}
