using System;
using System.Collections.Generic;

namespace Liftoff.Daemon.Configuration {

    internal class HostConfiguration {

        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string ServiceName { get; set; }
        public ICollection<string> Dependencies { get; private set;}
        public Account UserAccount { get; set; }
        public IBuildDaemons Builder { get; set; }
        public IControlDaemons Controller { get; set; }

        public HostConfiguration() {
            Dependencies = new List<string>();
        }
    }
}