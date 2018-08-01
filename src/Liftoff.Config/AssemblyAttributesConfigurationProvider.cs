using System;
using System.Reflection;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Liftoff.Config
{
    public class AssemblyAttributesConfigurationProvider : ConfigurationProvider
    {
        private readonly Assembly _assembly;

        public AssemblyAttributesConfigurationProvider(Assembly assembly)
        {
            _assembly = assembly;
        }

        public override void Load()
        {
            Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                ["assembly:company"] = (_assembly.GetCustomAttribute(typeof(AssemblyCompanyAttribute)) as AssemblyCompanyAttribute)?.Company ?? "Unknown",
                ["assembly:product"] = (_assembly.GetCustomAttribute(typeof(AssemblyProductAttribute)) as AssemblyProductAttribute)?.Product ?? "Unknown",
                ["assembly:name"] = _assembly.GetName().Name
            };
        }
    }
}
