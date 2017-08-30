using System;

namespace Liftoff.Service
{
    public static class HostFactory {

        public static void Run(Action<HostConfigurator> configureCallback) {
            var configurator = new DefaultHostConfigurator();
            configureCallback(configurator);
            
        }
    }
}
