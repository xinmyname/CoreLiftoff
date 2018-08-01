using Microsoft.Extensions.Logging;

namespace Liftoff.Logging
{
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public void Dispose()
        {
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new ConsoleLogger();
        }
    }
}
