using System;

namespace Liftoff.Daemon.Configuration {
    
    public interface IConfigureHosts {

        IConfigureHosts SetDescription(string description);
        IConfigureHosts SetDisplayName(string displayName);
        IConfigureHosts SetServiceName(string serviceName);
    }

    internal class HostConfigurator : IConfigureHosts { 

        public HostConfiguration Configuration { get; private set; }

        public HostConfigurator() {
            Configuration = new HostConfiguration();
        }

        public IConfigureHosts SetDescription(string description) {
            Configuration.Description = description;
            return this;
        }

        public IConfigureHosts SetDisplayName(string displayName) {
            Configuration.DisplayName = displayName;
            return this;
        }

        public IConfigureHosts SetServiceName(string serviceName) {
            Configuration.ServiceName = serviceName;
            return this;
        }
    }
}
