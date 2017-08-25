using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;
using MailKit.Net.Smtp;
using MimeKit;
using MailKit;

[assembly: InternalsVisibleTo("Liftoff.Tests")]

namespace Liftoff.Logging {

    internal class SmtpLogger : ILogger {

        private readonly IMailTransport _mailTransport;
        private readonly SmtpOptions _options;

        public SmtpLogger(IMailTransport mailTransport, SmtpOptions options) {
            _mailTransport = mailTransport;
            _options = options;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {

            if (logLevel != LogLevel.Critical)
                return;

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_options.From));
            message.To.AddRange(_options.Recipients.Select(r => new MailboxAddress(r)));
            message.Subject = $"Critical Error in {_options.Source} on {_options.ComputerName}";
            message.Body = new TextPart("plain") { Text = formatter(state, exception) };

            _mailTransport.Connect(_options.Host);

            if (_options.UserName != null && _options.Password != null)
                _mailTransport.Authenticate(_options.UserName, _options.Password);

            _mailTransport.Send(message);
            _mailTransport.Disconnect(true);
        }

        public bool IsEnabled(LogLevel logLevel) {
            return logLevel == LogLevel.Critical;
        }

        public IDisposable BeginScope<TState>(TState state) {
            return NullScope.Instance;
        }
    }
}
