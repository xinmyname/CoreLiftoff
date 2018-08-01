using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Liftoff.Config
{
    public static class AssemblyAttributesExtensions
    {
        public static IConfigurationBuilder AddCallingAssemblyAttributes(this IConfigurationBuilder configurationBuilder, Assembly assembly)
        {
            configurationBuilder.Add(new AssemblyAttributesConfigurationSource(assembly));

            return configurationBuilder;
        }
    }
}