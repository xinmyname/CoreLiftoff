using System;

namespace Liftoff.Service
{
    public static class HostFactory {

        public static void Run(Action<HostConfigurator> callback) {
            var configurator = new DefaultHostConfigurator();
            callback(configurator);
            ServiceConfiguration configuration = configurator.Configuration;
        }
    }
}
