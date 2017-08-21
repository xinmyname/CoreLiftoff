using System;
using Liftoff.Logging;
using Microsoft.Extensions.Logging;

namespace SampleBasicLogging {

    class Bootstrapper {

        static void Main(string[] args) {

            ILogger log = LogFactory.GetDefaultLogger();

            var asmAttrs = typeof(Bootstrapper).Assembly.GetCustomAttributes(true);

            log.LogInformation("Hello world!");
        }
    }
}
