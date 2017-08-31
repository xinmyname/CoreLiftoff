using System;

namespace Liftoff.Service
{
    public static class DependencyExtensions {
        
        public static IConfigureHosts DependsOn(this IConfigureHosts configurator, string name) {
            Configuration configuration = ((HostConfigurator)configurator).Configuration;
            configuration.Dependencies.Add(name);
            return configurator;
        }
    }
}
