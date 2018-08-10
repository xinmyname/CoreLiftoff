using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions.Internal;

namespace Liftoff.Logging
{
    internal class RollingFileLogger : ILogger, IDisposable
    {
        private readonly IKeepTime _timeKeeper;
        private readonly IManageFiles _fileManager;
        private readonly RollingFileOptions _options;
        private readonly object _writeLock = new object();

        private DateTime? _lastWriteDate;
        private StreamWriter _writer;

        public RollingFileLogger(IKeepTime timeKeeper, IManageFiles fileManager, RollingFileOptions options)
        {
            _timeKeeper = timeKeeper;
            _fileManager = fileManager;
            _options = options;

            string logFilePath = _options.LogFilePath;

            System.Diagnostics.Debug.Print($"Rolling log file: {logFilePath}");

            if (fileManager.Exists(logFilePath))
                _lastWriteDate = fileManager.GetLastWriteDate(logFilePath);
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            string logFilePath = _options.LogFilePath;
            DateTime curWriteTime = _timeKeeper.Now();
            DateTime curWriteDate = new DateTime(curWriteTime.Year, curWriteTime.Month, curWriteTime.Day);
            string level = logLevel.ToString().ToUpper();
            string timestamp = curWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            string user = System.Environment.UserName; // This should probably be abstracted away so it's testable
            string message = formatter(state, exception);
            Task deleteOldestTask = null;

            lock (_writeLock)
            {
                if (_lastWriteDate != null)
                {
                    DateTime lastWriteDate = _lastWriteDate.Value;

                    if (curWriteDate > lastWriteDate)
                    {
                        _writer?.Close();
                        _writer = null;

                        string rolledDate = lastWriteDate.ToString("yyyyMMdd");
                        string rolledFilePath = $"{logFilePath}.{rolledDate}";
                        _fileManager.Move(logFilePath, rolledFilePath);

                        deleteOldestTask = new Task(() =>
                        {
                            DateTime oldestDate = curWriteDate.AddDays(-1 * _options.MaximumAgeInDays);
                            string oldestFilePath = $"{logFilePath}.{oldestDate:yyyyMMdd}";

                            if (_fileManager.Exists(oldestFilePath))
                                _fileManager.Delete(oldestFilePath);
                        });
                    }
                }

                if (_writer == null)
                    _writer = _fileManager.OpenStreamWriter(_options.LogFilePath, FileAccess.ReadWrite, FileShare.Read);

                _writer.WriteLine($"{level}\t{timestamp}\t{user}\t{message}");
                _writer.Flush();
                _lastWriteDate = curWriteDate;
            }

            deleteOldestTask?.Start();
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return NullScope.Instance;
        }

        public void Dispose()
        {
            _writer?.Dispose();
        }
    }
}
