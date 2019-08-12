using System;

namespace Liftoff.Service
{
    public class ServiceConfigurator<T>
    {
        public ServiceObjectManager<T> ServiceObjectManager { get; private set; }

        public ServiceConfigurator()
        {
            ServiceObjectManager = new ServiceObjectManager<T>();
        }

        public void ConstructUsing(Func<T> constructor)
        {
            ServiceObjectManager.Constructor = constructor;
        }

        public void WhenStarted(Action<T> startAction)
        {
            ServiceObjectManager.StartAction = startAction;
        }

        public void WhenStopped(Action<T> stopAction)
        {
            ServiceObjectManager.StopAction = stopAction;
        }
    }
}