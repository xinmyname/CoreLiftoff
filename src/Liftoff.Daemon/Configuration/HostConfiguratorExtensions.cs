using System;

namespace Liftoff.Daemon.Configuration {
    
    public static class DependencyExtensions {
        
        public static IConfigureHosts DependsOn(this IConfigureHosts configurator, string name) {
            HostConfiguration configuration = ((HostConfigurator)configurator).Configuration;
            configuration.Dependencies.Add(name);
            return configurator;
        }
    }

    public static class RunAsExtensions {

        public static IConfigureHosts RunAs(this IConfigureHosts configurator, string userName, string password) {
            HostConfiguration configuration = ((HostConfigurator)configurator).Configuration;
            configuration.UserAccount = new Account(userName, password);
            return configurator;
        }

#if DAEMON_PLATFORM_WINDOWS
        public static IConfigureHosts RunAsNetworkService(this IConfigureHosts configurator) {
            HostConfiguration configuration = ((HostConfigurator)configurator).Configuration;
            configuration.UserAccount = WindowsAccount.NetworkService;
            return configurator;
        }
#endif       
    }
    
    public static class ServiceExtensions {

        public static IConfigureHosts Service<T>(this IConfigureHosts configurator, Action<IConfigureDaemons<T>> callback) where T : class {
            HostConfiguration configuration = ((HostConfigurator)configurator).Configuration;
            callback(new DaemonConfigurator<T>(configuration));
            return configurator;
        }
    }    
}
