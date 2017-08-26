using System;

namespace Liftoff.Service
{
    public static class DependencyExtensions {
        
        public static HostConfigurator AddDependency(this HostConfigurator configurator, string name) {
            throw new NotImplementedException();
        }

        public static HostConfigurator DependsOn(this HostConfigurator configurator, string name) {
            return AddDependency(configurator, name);
        }
    }
}
