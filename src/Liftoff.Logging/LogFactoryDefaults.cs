using System;

namespace Liftoff.Logging
{
    public static class LogFactoryDefaults {

        public static Func<string> AppSettingsFilename = () => "appsettings.json";
    }
}
