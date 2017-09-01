using System;

namespace Liftoff.Daemon.Configuration {
    
    public interface IConfigureDaemons<T> {

        IConfigureDaemons<T> ConstructUsing(Func<string,T> factory);
        IConfigureDaemons<T> WhenStarted(Action<T> startAction);
        IConfigureDaemons<T> WhenStopped(Action<T> stopAction);
    } 

    internal class DaemonConfigurator<T> : IConfigureDaemons<T> {

        private readonly HostConfiguration _config;
        private readonly DaemonBuilder<T> _daemonBuilder;
        private readonly DaemonController<T> _daemonController;

        public DaemonConfigurator(HostConfiguration config) {
            _daemonBuilder = new DaemonBuilder<T>();
            _daemonController = new DaemonController<T>();

            _config = config;
            _config.Builder = _daemonBuilder;
            _config.Controller = _daemonController;
        }

        public IConfigureDaemons<T> ConstructUsing(Func<string,T> factory) {
            _daemonBuilder.Factory = factory;
            return this;
        }

        public IConfigureDaemons<T> WhenStarted(Action<T> startAction) {
            _daemonController.StartAction = startAction;
            return this;
        }

        public IConfigureDaemons<T> WhenStopped(Action<T> stopAction) {
            _daemonController.StopAction = stopAction;
            return this;
        }
    }
}
