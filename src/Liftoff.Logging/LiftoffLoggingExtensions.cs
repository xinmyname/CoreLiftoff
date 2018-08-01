using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace Liftoff.Logging
{
    public static class LiftoffLoggingExtensions {

        public static ILoggerFactory AddLiftoffProviders(this ILoggerFactory loggerFactory, IConfiguration config)
        {

            loggerFactory.AddProvider(new ConsoleLoggerProvider());
            loggerFactory.AddProvider(new RollingFileProvider(config));
            loggerFactory.AddProvider(new SmtpProvider(config));

            return loggerFactory;
        }

        public static ILoggingBuilder AddLiftoffProviders(this ILoggingBuilder builder, IConfiguration config)
        {
            builder.AddProvider(new ConsoleLoggerProvider());
            builder.AddProvider(new RollingFileProvider(config));
            builder.AddProvider(new SmtpProvider(config));

            return builder;
        }
    }
}
