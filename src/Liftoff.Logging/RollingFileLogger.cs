using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;

namespace Liftoff.Logging
{
    internal class RollingFileLogger : ILogger
    {
        private readonly IKeepTime _timeKeeper;
        private readonly IManageFiles _fileManager;
        private readonly RollingFileOptions _options;

        private DateTime? _lastWriteDate;

        public RollingFileLogger(IKeepTime timeKeeper, IManageFiles fileManager, RollingFileOptions options)
        {
            _timeKeeper = timeKeeper;
            _fileManager = fileManager;
            _options = options;

            string logFilePath = _options.LogFilePath;

            if (fileManager.Exists(logFilePath))
                _lastWriteDate = fileManager.GetLastWriteDate(logFilePath);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string logFilePath = _options.LogFilePath;
            DateTime curWriteTime = _timeKeeper.Now();
            DateTime curWriteDate = new DateTime(curWriteTime.Year, curWriteTime.Month, curWriteTime.Day);

            if (_lastWriteDate != null)
            {
                if (curWriteDate > _lastWriteDate.Value)
                {
                    string rolledDate = _lastWriteDate.Value.ToString("yyyyMMdd");
                    string rolledFilePath = $"{logFilePath}.{rolledDate}";
                    _fileManager.Move(logFilePath, rolledFilePath);

                    DateTime oldestDate = curWriteDate.AddDays(-1 * _options.MaximumAgeInDays);
                    string oldestFilePath = $"{logFilePath}.{rolledDate:yyyyMMdd}";

                    if (_fileManager.Exists(oldestFilePath))
                        _fileManager.Delete(oldestFilePath);
                }
            }

            string level = logLevel.ToString().ToUpper();
            string timestamp = curWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            string user = System.Environment.UserName; // This should probably be abstracted away so it's testable
            string message = formatter(state, exception);

            _fileManager.WriteLine(logFilePath, $"{level}\t{timestamp}\t{user}\t{message}");
            _lastWriteDate = curWriteDate;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NullScope.Instance;
        }
    }
}
