using System;

namespace Liftoff.Daemon {

    internal interface IBuildDaemons {
    }

    internal class DaemonBuilder<T> : IBuildDaemons {
        public Func<string,T> Factory { get; set; }
    }   
}
