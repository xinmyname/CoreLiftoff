namespace Liftoff.Logging
{
    public class RollingFileOptions
    {
        public string LogFilePath { get; set; }
        public int MaximumAgeInDays { get; set; }
    }
}
