using System;
using Liftoff.Logging;
using Microsoft.Extensions.Logging;

namespace SampleBasicLogging {

    class Bootstrapper {

        static void Main(string[] args) {

            ILogger log = LogFactory.GetDefaultLogger();

            log.Info("Hello world!");
            log.Critical("VERY BAD!");
        }
    }
}
