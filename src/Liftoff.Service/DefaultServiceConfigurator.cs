using System;

namespace Liftoff.Service
{

    public interface IControlServices {
    }

    public class ServiceController<T> : IControlServices {
        public Action<T> StartAction { get; set; }
        public Action<T> StopAction { get; set; }
    }

    public interface IBuildServices {
    }

    public class ServiceBuilder<T> : IBuildServices {
        public Func<string,T> Factory { get; set; }
    }
    
    public class DefaultServiceConfigurator<T> : ServiceConfigurator<T> {

        private readonly ServiceConfiguration _config;
        private readonly ServiceBuilder<T> _serviceBuilder;
        private readonly ServiceController<T> _serviceController;

        public DefaultServiceConfigurator(ServiceConfiguration config) {
            _serviceBuilder = new ServiceBuilder<T>();
            _serviceController = new ServiceController<T>();

            _config = config;
            _config.Builder = _serviceBuilder;
            _config.Controller = _serviceController;
        }

        public ServiceConfigurator<T> ConstructUsing(Func<string,T> factory) {
            _serviceBuilder.Factory = factory;
            return this;
        }

        public ServiceConfigurator<T> WhenStarted(Action<T> startAction) {
            _serviceController.StartAction = startAction;
            return this;
        }

        public ServiceConfigurator<T> WhenStopped(Action<T> stopAction) {
            _serviceController.StopAction = stopAction;
            return this;
        }
    }
}
