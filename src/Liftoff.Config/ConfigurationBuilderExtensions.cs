using System.IO;
using Liftoff.Config;
using Microsoft.Extensions.Configuration;

public static class ConfigurationBuilderExtensions {

    public static IConfigurationBuilder AddDefaultSources(this IConfigurationBuilder builder) {

        string appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), ConfigurationDefaults.AppSettingsFilename());

        if (File.Exists(appSettingsPath))
            builder.AddJsonFile(appSettingsPath);

        builder.AddCallingAssemblyAttributes(System.Reflection.Assembly.GetCallingAssembly());
        builder.AddEnvironmentVariables();

        return builder;
    }
}