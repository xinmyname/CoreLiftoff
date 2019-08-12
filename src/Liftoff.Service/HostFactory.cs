using System;
using System.IO;
using System.Linq;
using System.ServiceProcess;

namespace Liftoff.Service
{
    public static class HostFactory
    {
        public static void Run(Action<HostConfigurator> configureHostAction)
        {
            try
            {
                var hostConfigurator = new HostConfigurator();
                configureHostAction(hostConfigurator);

                var serviceRunner = new ServiceRunner(hostConfigurator.ServiceObjectManager);
                serviceRunner.Run();
            }
            catch (Exception ex)
            {
                ServiceLogger.Fatal(ex.Message, ex);
            }
        }
    }
}