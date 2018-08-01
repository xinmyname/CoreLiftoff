using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;
using System.Net.Mail;

namespace Liftoff.Logging
{
    internal class SmtpLogger : ILogger
    {
        private readonly ISendEmail _mailSender;
        private readonly SmtpOptions _options;

        public SmtpLogger(ISendEmail mailSender, SmtpOptions options)
        {
            _mailSender = mailSender;
            _options = options;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            if (logLevel != LogLevel.Critical)
                return;

            string bodyText = (exception != null)
                ? $"{formatter(state, exception)}\n\n{exception.StackTrace}"
                : formatter(state, null);

            var message = new MailMessage
            {
                From = new MailAddress(_options.From),
                Subject = $"Critical Error in {_options.Source} on {_options.ComputerName}",
                Body = bodyText
            };

            message.To.Add(String.Join(",", _options.Recipients));

            _mailSender.Send(message);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == LogLevel.Critical;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NullScope.Instance;
        }
    }
}
