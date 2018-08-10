using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Liftoff.Logging
{
    public class SmtpProvider : ILoggerProvider
    {
        private readonly Lazy<ILogger> _lazyLogger;

        public SmtpProvider(IConfiguration config)
        {
            _lazyLogger = new Lazy<ILogger>(() =>
            {
                string productName = config["assembly:product"];
                string appName = config["assembly:name"];

                string source = (productName == appName)
                    ? productName
                    : $"{productName} - {appName}";

                string criticalErrorRecipient = config["criticalErrorRecipient"] ?? String.Empty;

                var options = new SmtpOptions
                {
                    ComputerName = Environment.MachineName,
                    Host = config["mail:host"],
                    From = config["mail:from"],
                    Recipients = criticalErrorRecipient.Split(';', ','),
                    UserName = config["mail:username"],
                    Password = config["mail:password"],
                    UseDefaultCredentials = false,
                    Source = source
                };

                if (String.IsNullOrEmpty(options.Host) || String.IsNullOrEmpty(options.From) || !options.Recipients.Any())
                    return NullLogger.Instance;

                return new SmtpLogger(new EmailSender(options), options);
            });
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _lazyLogger.Value;
        }

        public void Dispose()
        {
        }
    }
}
