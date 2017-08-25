using System;
using Microsoft.Extensions.Logging;

namespace Liftoff.Logging {

    public static class LoggerExtensions {

        public static void Debug(this ILogger logger, string message) {
            logger.LogDebug(message);
        }

        public static void Debug(this ILogger logger, Exception exception) {
            logger.LogDebug(exception, exception.Message);
        }

        public static void Debug(this ILogger logger, Exception exception, string message) {
            logger.LogDebug(exception, message);
        }

        public static void Info(this ILogger logger, string message) {
            logger.LogInformation(message);
        }

        public static void Info(this ILogger logger, Exception exception) {
            logger.LogInformation(exception, exception.Message);
        }

        public static void Info(this ILogger logger, Exception exception, string message) {
            logger.LogInformation(exception, message);
        }

        public static void Warn(this ILogger logger, string message) {
            logger.LogWarning(message);
        }

        public static void Warn(this ILogger logger, Exception exception) {
            logger.LogWarning(exception, exception.Message);
        }

        public static void Warn(this ILogger logger, Exception exception, string message) {
            logger.LogWarning(exception, message);
        }

        public static void Error(this ILogger logger, string message) {
            logger.LogError(message);
        }

        public static void Error(this ILogger logger, Exception exception) {
            logger.LogError(exception, exception.Message);
        }

        public static void Error(this ILogger logger, Exception exception, string message) {
            logger.LogError(exception, message);
        }

        public static void Critical(this ILogger logger, string message) {
            logger.LogCritical(message);
        }

        public static void Critical(this ILogger logger, Exception exception) {
            logger.LogCritical(exception, exception.Message);
        }

        public static void Critical(this ILogger logger, Exception exception, string message) {
            logger.LogCritical(exception, message);
        }
    }
}
