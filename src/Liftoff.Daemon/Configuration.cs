using System;
using System.Collections.Generic;

namespace Liftoff.Daemon {

    internal class Configuration {

        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string ServiceName { get; set; }
        public ICollection<string> Dependencies { get; private set;}
        public Account UserAccount { get; set; }
        public IBuildDaemons Builder { get; set; }
        public IControlDaemons Controller { get; set; }

        public Configuration() {
            Dependencies = new List<string>();
        }
    }
}