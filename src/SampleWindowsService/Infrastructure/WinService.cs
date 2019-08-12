using Microsoft.Extensions.Logging;
using Liftoff.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleWindowsService.Infrastructure
{
    class WinService
    {
        private readonly ILogger _log;

        public WinService(ILogger<WinService> log)
        {
            log.Info($"SampleWindowsService Service v{typeof(WinService).Assembly.GetName().Version}");
            _log = log;
        }

        public void Start()
        {
        }

        public void Stop()
        {

        }
    }
}
