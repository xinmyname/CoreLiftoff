using System;

namespace Liftoff.Daemon {
    
    public static class DependencyExtensions {
        
        public static IConfigureHosts DependsOn(this IConfigureHosts configurator, string name) {
            Configuration configuration = ((HostConfigurator)configurator).Configuration;
            configuration.Dependencies.Add(name);
            return configurator;
        }
    }

    public static class RunAsExtensions {

        public static IConfigureHosts RunAs(this IConfigureHosts configurator, string userName, string password) {
            Configuration configuration = ((HostConfigurator)configurator).Configuration;
            configuration.UserAccount = new Account(userName, password);
            return configurator;
        }

#if DAEMON_PLATFORM_WINDOWS
        public static IConfigureHosts RunAsNetworkService(this IConfigureHosts configurator) {
            Configuration configuration = ((HostConfigurator)configurator).Configuration;
            configuration.UserAccount = WindowsAccount.NetworkService;
            return configurator;
        }
#endif       
    }
    
    public static class ServiceExtensions {

        public static IConfigureHosts Service<T>(this IConfigureHosts configurator, Action<IConfigureDaemons<T>> callback) where T : class {
            Configuration configuration = ((HostConfigurator)configurator).Configuration;
            callback(new DaemonConfigurator<T>(configuration));
            return configurator;
        }
    }    
}
