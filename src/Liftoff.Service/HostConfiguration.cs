using System;
using System.Collections.Generic;

namespace Liftoff.Service {

    public class HostConfiguration {

        public string Description { get; set; }
        public string DisplayName { get; set; }
        public string ServiceName { get; set; }
        public ICollection<string> Dependencies { get; private set;}
        public Account UserAccount { get; set; }
        

        public HostConfiguration() {
            Dependencies = new List<string>();
        }
    }
}