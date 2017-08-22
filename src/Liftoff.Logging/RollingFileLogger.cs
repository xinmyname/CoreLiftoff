using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;

namespace Liftoff.Logging
{
    internal class RollingFileLogger : ILogger {

        private readonly IKeepTime _timeKeeper;
        private readonly IManageFiles _fileManager;
        private readonly RollingFileOptions _options;

        public RollingFileLogger(IKeepTime timeKeeper, IManageFiles fileManager, RollingFileOptions options) {

            _timeKeeper = timeKeeper;
            _fileManager = fileManager;
            _options = options;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter) {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel logLevel) {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state) {
            return NullScope.Instance;
        }
    }
}
