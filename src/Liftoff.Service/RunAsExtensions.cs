using System;

namespace Liftoff.Service
{
    public static class RunAsExtensions {

        public static HostConfigurator RunAs(this HostConfigurator configurator, string userName, string password) {
            throw new NotImplementedException();
        }

        public static HostConfigurator RunAsNetworkService(this HostConfigurator configurator) {
            throw new NotImplementedException();
        }
    }
}
