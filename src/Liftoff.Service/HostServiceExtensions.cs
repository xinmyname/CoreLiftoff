using System;

namespace Liftoff.Service {

    public static class ServiceExtensions {

        public static HostConfigurator Service<T>(this HostConfigurator configurator, Action<ServiceConfigurator<T>> callback) where T : class {

            var x = new DefaultServiceConfigurator<T>(configurator.Configuration);

            callback(x);

            

            return configurator;
        }
    }

/* 
        x.Service<PlatformService>(s => {
            ILogger log = LogFactory.GetDefaultLogger();

            log.Info("Initializing...");

            s.ConstructUsing(name => new PlatformService(log));

            s.WhenStarted(ps => ps.Start());
            s.WhenStopped(ps => ps.Stop());
        });
*/

}
