using System;

namespace Liftoff.Daemon {
    
    public static class HostFactory {

        public static void Run(Action<IConfigureHosts> callback) {
            var configurator = new HostConfigurator();
            callback(configurator);
            Configuration configuration = configurator.Configuration;
        }
    }
}
