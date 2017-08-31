using System;

namespace Liftoff.Service {

    public static class ServiceExtensions {

        public static IConfigureHosts Service<T>(this IConfigureHosts configurator, Action<IConfigureDaemons<T>> callback) where T : class {
            Configuration configuration = ((HostConfigurator)configurator).Configuration;
            callback(new DaemonConfigurator<T>(configuration));
            return configurator;
        }
    }
}
