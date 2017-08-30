using System;

namespace Liftoff.Service
{
    public class DefaultServiceConfigurator<T> : ServiceConfigurator<T> {

        private readonly HostConfiguration _config;

        public DefaultServiceConfigurator(HostConfiguration config) {
            _config = config;
        }

        public ServiceConfigurator<T> ConstructUsing(Func<string,T> factory) {
            throw new NotImplementedException();
            return this;
        }

        public ServiceConfigurator<T> WhenStarted(Action<T> startAction) {
            throw new NotImplementedException();
            return this;
        }

        public ServiceConfigurator<T> WhenStopped(Action<T> stopAction) {
            throw new NotImplementedException();
            return this;
        }
    }
}
