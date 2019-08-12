using System;
using System.Collections.Generic;

namespace Liftoff.Service
{
    public class HostConfigurator
    {
        public IManageServiceObjects ServiceObjectManager { get; private set; }

        public HostConfigurator()
        {
        }

        public void ConfigureLogging(
            Action<string, Exception> logDebugAction,
            Action<string, Exception> logInfoAction,
            Action<string, Exception> logWarnAction,
            Action<string, Exception> logErrorAction,
            Action<string, Exception> logFatalAction)
        {
            ServiceLogger.Configure(logDebugAction, logInfoAction, logWarnAction, logErrorAction, logFatalAction);
        }

        public void Service<T>(Action<ServiceConfigurator<T>> configureServiceAction)
        {
            var serviceConfigurator = new ServiceConfigurator<T>();
            configureServiceAction(serviceConfigurator);

            ServiceObjectManager = serviceConfigurator.ServiceObjectManager;
        }
    }
}