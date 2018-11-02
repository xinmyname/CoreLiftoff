using System;
using System.IO;
using System.Reflection;

namespace Liftoff.Config
{
    public static class ConfigurationDefaults
    {
        public static readonly Func<string> AppSettingsFilename = () => "appsettings.json";
        public static readonly Func<string> AppPath = () => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
    }
}