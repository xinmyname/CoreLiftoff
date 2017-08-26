using System;

namespace Liftoff.Service
{
    public interface ServiceConfigurator<T> {

        ServiceConfigurator<T> ConstructUsing(Func<string,T> factory);
        ServiceConfigurator<T> WhenStarted(Action<T> startAction);
        ServiceConfigurator<T> WhenStopped(Action<T> stopAction);
    } 
}
