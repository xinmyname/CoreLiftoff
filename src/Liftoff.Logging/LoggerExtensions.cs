using System;
using Microsoft.Extensions.Logging;

namespace Liftoff.Logging
{
    public static class LoggerExtensions
    {
        public static void Debug(this ILogger logger, string message, Exception exception = null)
        {
            logger.LogDebug(exception, message);
        }

        public static void Info(this ILogger logger, string message, Exception exception = null)
        {
            logger.LogInformation(exception, message);
        }

        public static void Warn(this ILogger logger, string message, Exception exception = null)
        {
            logger.LogWarning(exception, message);
        }

        public static void Error(this ILogger logger, string message, Exception exception = null)
        {
            logger.LogError(exception, message);
        }

        public static void Critical(this ILogger logger, string message, Exception exception = null)
        {
            logger.LogCritical(exception, message);
        }

        public static void Debug(this ILogger logger, Exception exception = null)
        {
            logger.LogDebug(exception, exception.Message);
        }

        public static void Info(this ILogger logger, Exception exception = null)
        {
            logger.LogInformation(exception, exception.Message);
        }

        public static void Warn(this ILogger logger, Exception exception = null)
        {
            logger.LogWarning(exception, exception.Message);
        }

        public static void Error(this ILogger logger,Exception exception = null)
        {
            logger.LogError(exception, exception.Message);
        }

        public static void Critical(this ILogger logger, Exception exception = null)
        {
            logger.LogCritical(exception, exception.Message);
        }
    }
}
