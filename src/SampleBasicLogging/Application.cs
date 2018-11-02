using System;
using Liftoff.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SampleBasicLogging
{
    class Application
    {
        private readonly ILogger<Application> _log;
        private readonly IConfiguration _config;

        public Application(ILogger<Application> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public void Run()
        {
            try
            {
                string toWhom = _config["criticalErrorRecipient"];

                _log.Info($"Send errors to: {toWhom}");
                _log.Info("Running...");

                throw new ApplicationException("FML");
            }
            catch (Exception ex)
            {
                _log.Critical(ex);
            }
        }
    }
}