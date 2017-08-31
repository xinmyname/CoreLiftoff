using System;
using Liftoff.Logging;
using Microsoft.Extensions.Logging;

namespace SampleBasicLogging {

    class Bootstrapper {

        static void Main(string[] args) {

            ILogger log = LogFactory.GetDefaultLogger();

            try {
                log.Info("Hello world!");
            } catch(Exception ex) {
                log.Critical(ex);
            }
        }
    }
}
