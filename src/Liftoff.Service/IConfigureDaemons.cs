using System;

namespace Liftoff.Service
{
    public interface IConfigureDaemons<T> {

        IConfigureDaemons<T> ConstructUsing(Func<string,T> factory);
        IConfigureDaemons<T> WhenStarted(Action<T> startAction);
        IConfigureDaemons<T> WhenStopped(Action<T> stopAction);
    } 
}
