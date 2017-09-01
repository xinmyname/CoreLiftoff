using System;
using Liftoff.Daemon.Configuration;

namespace Liftoff.Daemon {
    
    public static class HostFactory {

        public static void Run(Action<IConfigureHosts> callback) {
            var configurator = new HostConfigurator();
            callback(configurator);
            HostConfiguration configuration = configurator.Configuration;
        }
    }
}
