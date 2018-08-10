using System;
using Microsoft.Extensions.Logging;

namespace Liftoff.Logging
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        private readonly Lazy<ILogger> _lazyLogger;

        public ConsoleLoggerProvider()
        {
            _lazyLogger = new Lazy<ILogger>(() => new ConsoleLogger());
        }

        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return _lazyLogger.Value;
        }
    }
}
