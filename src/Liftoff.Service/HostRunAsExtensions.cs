using System;

namespace Liftoff.Service
{

    public static class RunAsExtensions {

        public static IConfigureHosts RunAs(this IConfigureHosts configurator, string userName, string password) {
            Configuration configuration = ((HostConfigurator)configurator).Configuration;
            configuration.UserAccount = new Account(userName, password);
            return configurator;
        }

#if SERVICE_PLATFORM_WINDOWS
        public static IConfigureHosts RunAsNetworkService(this IConfigureHosts configurator) {
            Configuration configuration = ((HostConfigurator)configurator).Configuration;
            configuration.UserAccount = WindowsAccount.NetworkService;
            return configurator;
        }
#endif       

    }
}
