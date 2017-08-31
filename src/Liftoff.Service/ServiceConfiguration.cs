using System;
using System.Collections.Generic;

namespace Liftoff.Service {

    public class ServiceConfiguration {

        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string ServiceName { get; set; }
        public ICollection<string> Dependencies { get; private set;}
        public Account UserAccount { get; set; }
        public IBuildServices Builder { get; set; }
        public IControlServices Controller { get; set; }

        public ServiceConfiguration() {
            Dependencies = new List<string>();
        }
    }
}