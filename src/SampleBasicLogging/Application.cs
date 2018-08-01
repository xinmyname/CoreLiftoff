using System;
using Liftoff.Logging;
using Microsoft.Extensions.Logging;

namespace SampleBasicLogging
{
    class Application
    {
        private readonly ILogger<Application> _log;

        public Application(ILogger<Application> log)
        {
            _log = log;
        }

        public void Run()
        {
            try
            {
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