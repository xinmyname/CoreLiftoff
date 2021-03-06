using System.IO;
using Microsoft.Extensions.Configuration;

namespace Liftoff.Config
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddLiftoffSources(this IConfigurationBuilder builder, string appSettingsPath = null)
        {
            if (appSettingsPath == null)
                appSettingsPath = Path.Combine(ConfigurationDefaults.AppPath(), ConfigurationDefaults.AppSettingsFilename());

            if (File.Exists(appSettingsPath))
                builder.AddJsonFile(appSettingsPath);

            builder.AddCallingAssemblyAttributes(System.Reflection.Assembly.GetEntryAssembly());
            builder.AddEnvironmentVariables();

            return builder;
        }
    }
}