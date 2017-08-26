using System;

namespace Liftoff.Service {

    public interface ServiceConfigurator<T> {

        ServiceConfigurator<T> ConstructUsing(Func<string,T> factory);
        ServiceConfigurator<T> WhenStarted(Action<T> startAction);
        ServiceConfigurator<T> WhenStopped(Action<T> stopAction);
    } 

    public class DefaultServiceConfigurator<T> : ServiceConfigurator<T> {

        public ServiceConfigurator<T> ConstructUsing(Func<string,T> factory) {
            throw new NotImplementedException();
        }

        public ServiceConfigurator<T> WhenStarted(Action<T> startAction) {
            throw new NotImplementedException();
        }

        public ServiceConfigurator<T> WhenStopped(Action<T> stopAction) {
            throw new NotImplementedException();
        }
    }

    public static class ServiceExtensions {

        public static HostConfigurator Service<T>(this HostConfigurator configurator, Action<ServiceConfigurator<T>> callback) where T : class {
            throw new NotImplementedException();
        }
    }

    public static class RunAsExtensions {

        public static HostConfigurator RunAs(this HostConfigurator configurator, string userName, string password) {
            throw new NotImplementedException();
        }

        public static HostConfigurator RunAsNetworkService(this HostConfigurator configurator) {
            throw new NotImplementedException();
        }
    }

    public static class DependencyExtensions {
        
        public static HostConfigurator AddDependency(this HostConfigurator configurator, string name) {
            throw new NotImplementedException();
        }

        public static HostConfigurator DependsOn(this HostConfigurator configurator, string name) {
            return AddDependency(configurator, name);
        }
    }

    public interface HostConfigurator {
        HostConfigurator SetDescription(string description);
        HostConfigurator SetDisplayName(string displayName);
        HostConfigurator SetServiceName(string serviceName);
    }

    public class DefaultHostConfigurator : HostConfigurator { 

        public HostConfigurator SetDescription(string description) {
            throw new NotImplementedException();
        }

        public HostConfigurator SetDisplayName(string displayName) {
            throw new NotImplementedException();
        }

        public HostConfigurator SetServiceName(string serviceName) {
            throw new NotImplementedException();
        }
    }

    public static class HostFactory {

        public static void Run(Action<HostConfigurator> configureCallback) {
            throw new NotImplementedException();
        }
    }
}
