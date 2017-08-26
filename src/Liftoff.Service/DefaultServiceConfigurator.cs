using System;

namespace Liftoff.Service
{
    public class DefaultServiceConfigurator<T> : ServiceConfigurator<T> {

        public ServiceConfigurator<T> ConstructUsing(Func<string,T> factory) {
            throw new NotImplementedException();
        }

        public ServiceConfigurator<T> WhenStarted(Action<T> startAction) {
            throw new NotImplementedException();
        }

        public ServiceConfigurator<T> WhenStopped(Action<T> stopAction) {
            throw new NotImplementedException();
        }
    }
}
