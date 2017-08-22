using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Liftoff.Config {

    public class AssemblyAttributesConfigurationSource : IConfigurationSource {

        private readonly Assembly _assembly;

        public AssemblyAttributesConfigurationSource(Assembly assembly) {
            _assembly = assembly;
        }

        public IConfigurationProvider Build(IConfigurationBuilder builder) {
            return new AssemblyAttributesConfigurationProvider(_assembly);
        }
    }
}
