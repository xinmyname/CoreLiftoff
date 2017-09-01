using System;

namespace Liftoff.Daemon {

    internal interface IControlDaemons {
    }

    internal class DaemonController<T> : IControlDaemons {
        public Action<T> StartAction { get; set; }
        public Action<T> StopAction { get; set; }
    }
}
