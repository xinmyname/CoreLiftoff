using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Liftoff.Logging {
    
    public class SmtpProvider : ILoggerProvider {

        private readonly IConfigurationRoot _config;

        public SmtpProvider(IConfigurationRoot config) {
            _config = config;
        }

        public ILogger CreateLogger(string categoryName) {
            throw new NotImplementedException();
        }

        public void Dispose() {
            throw new NotImplementedException();
        }
    }
}
