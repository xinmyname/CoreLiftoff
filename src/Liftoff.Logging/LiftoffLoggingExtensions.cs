using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Liftoff.Logging
{
    public static class LiftoffLoggingExtensions
    {
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

        public static ILoggingBuilder AddLiftoffProviders(this ILoggingBuilder builder)
        {
            builder.Services.AddSingleton<ILoggerProvider, ConsoleLoggerProvider>();
            builder.Services.AddSingleton<ILoggerProvider, RollingFileProvider>();
            builder.Services.AddSingleton<ILoggerProvider, SmtpProvider>();

            return builder;
        }
    }
}
