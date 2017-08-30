using System;

namespace Liftoff.Service
{
    public static class DependencyExtensions {
        
        public static HostConfigurator DependsOn(this HostConfigurator configurator, string name) {
            configurator.Configuration.Dependencies.Add(name);
            return configurator;
        }
    }
}
