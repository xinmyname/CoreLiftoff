using System;

namespace Liftoff.Config
{
    public static class ConfigurationDefaults
    {
        public static readonly Func<string> AppSettingsFilename = () => "appsettings.json";
    }
}