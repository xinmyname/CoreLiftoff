using System;
using Liftoff.Logging;
using Liftoff.Daemon;
using Microsoft.Extensions.Logging;

namespace SampleWindowsService {

    public class PlatformService {

        private readonly ILogger _log;

        public PlatformService(ILogger log) {
            _log = log;
        }

        public void Start() {
            _log.Info("Started!");
        }

        public void Stop() {
            _log.Info("Stopped!");
        }
    }

    class Bootstrapper {

        static void Main(string[] args) {

            Console.WriteLine("I'm sure everything is fine.");

            HostFactory.Run(x => {
                x.Service<PlatformService>(s => {
                    ILogger log = LogFactory.GetDefaultLogger();

                    log.Info("Initializing...");

                    s.ConstructUsing(name => new PlatformService(log));

                    s.WhenStarted(ps => ps.Start());
                    s.WhenStopped(ps => ps.Stop());
                });

                x.DependsOn("Workstation");
                x.RunAsNetworkService();

                x.SetDescription("Provides a unique and interesting sample experience.");
                x.SetDisplayName("Liftoff Sample Service");
                x.SetServiceName("LiftoffSampleService");                
            });
        }
    }
}
