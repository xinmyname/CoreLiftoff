using System;

namespace Liftoff.Service
{
    public class DefaultHostConfigurator : HostConfigurator { 

        public ServiceConfiguration Configuration { get; private set; }

        public DefaultHostConfigurator() {
            Configuration = new ServiceConfiguration();
        }

        public HostConfigurator SetDescription(string description) {
            Configuration.Description = description;
            return this;
        }

        public HostConfigurator SetDisplayName(string displayName) {
            Configuration.DisplayName = displayName;
            return this;
        }

        public HostConfigurator SetServiceName(string serviceName) {
            Configuration.ServiceName = serviceName;
            return this;
        }
    }
}
