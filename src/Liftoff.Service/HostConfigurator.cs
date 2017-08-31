using System;

namespace Liftoff.Service
{
    internal class HostConfigurator : IConfigureHosts { 

        public Configuration Configuration { get; private set; }

        public HostConfigurator() {
            Configuration = new Configuration();
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
