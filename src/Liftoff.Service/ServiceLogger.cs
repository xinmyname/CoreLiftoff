using System;

namespace Liftoff.Service
{
    public static class ServiceLogger
    {
        public static void Configure(
            Action<string, Exception> logDebugAction,
            Action<string, Exception> logInfoAction,
            Action<string, Exception> logWarnAction,
            Action<string, Exception> logErrorAction,
            Action<string, Exception> logFatalAction)
        {
            LogDebug = logDebugAction;
            LogInfo = logInfoAction;
            LogWarn = logWarnAction;
            LogInfo = logInfoAction;
            LogFatal = logFatalAction;
        }

        public static Action<string, Exception> LogDebug = (message, ex) =>
        {
            Write("DEBUG", message, ex);
        };

        public static Action<string, Exception> LogInfo = (message, ex) =>
        {
            Write("INFO", message, ex);
        };

        public static Action<string, Exception> LogWarn = (message, ex) =>
        {
            Write("WARN", message, ex);
        };

        public static Action<string, Exception> LogError = (message, ex) =>
        {
            Write("ERROR", message, ex);
        };

        public static Action<string, Exception> LogFatal = (message, ex) =>
        {
            Write("FATAL", message, ex);
        };

        public static void Debug(string message, Exception ex = null)
        {
            LogDebug(message, ex);
        }

        public static void Info(string message, Exception ex = null)
        {
            LogInfo(message, ex);
        }

        public static void Warn(string message, Exception ex = null)
        {
            LogWarn(message, ex);
        }

        public static void Error(string message, Exception ex = null)
        {
            LogError(message, ex);
        }

        public static void Fatal(string message, Exception ex = null)
        {
            LogFatal(message, ex);
        }

        private static void Write(string severity, string message, Exception ex)
        {
            Console.WriteLine($"{severity}\t{message}");
            Console.WriteLine(ex);
        }
    }
}