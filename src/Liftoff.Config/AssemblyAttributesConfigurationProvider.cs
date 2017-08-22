using System;
using System.Reflection;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Liftoff.Config {

    public class AssemblyAttributesConfigurationProvider : ConfigurationProvider {

        private readonly Assembly _assembly;

        public AssemblyAttributesConfigurationProvider(Assembly assembly) {
            _assembly = assembly;
        }

        public override void Load() {
            
            Data = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            Data["Assembly:Company"] = (_assembly.GetCustomAttribute(typeof(AssemblyCompanyAttribute)) as AssemblyCompanyAttribute)?.Company;
            Data["Assembly:Product"] = (_assembly.GetCustomAttribute(typeof(AssemblyProductAttribute)) as AssemblyProductAttribute)?.Product;
            Data["Assembly:Name"] = _assembly.GetName().Name;        
        }
    }
}
