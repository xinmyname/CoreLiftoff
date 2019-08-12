using System;
using Microsoft.Extensions.Logging;

namespace Liftoff.Logging
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        private static object _lazyLock = new object();
        private static Lazy<ILogger> _lazyLogger;

        public ConsoleLoggerProvider()
        {
            lock (_lazyLock)
            {
                if (_lazyLogger != null)
                    return;

                _lazyLogger = new Lazy<ILogger>(() => new ConsoleLogger());
            }
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
