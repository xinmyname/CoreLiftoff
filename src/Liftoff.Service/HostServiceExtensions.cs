using System;

namespace Liftoff.Service {

    public static class ServiceExtensions {

        public static HostConfigurator Service<T>(this HostConfigurator configurator, Action<ServiceConfigurator<T>> callback) where T : class {
            callback(new DefaultServiceConfigurator<T>(configurator.Configuration));
            return configurator;
        }
    }
}
