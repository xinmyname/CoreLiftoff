using System;

namespace Liftoff.Service
{

    public static class RunAsExtensions {

        public static HostConfigurator RunAs(this HostConfigurator configurator, string userName, string password) {
            configurator.Configuration.UserAccount = new Account(userName, password);
            return configurator;
        }

#if SERVICE_PLATFORM_WINDOWS
        public static HostConfigurator RunAsNetworkService(this HostConfigurator configurator) {
            configurator.Configuration.UserAccount = WindowsAccount.NetworkService;
            return configurator;
        }
#endif       

    }
}
