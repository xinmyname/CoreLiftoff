namespace Liftoff.Service {

    public interface HostConfigurator {

        HostConfiguration Configuration { get; }

        HostConfigurator SetDescription(string description);
        HostConfigurator SetDisplayName(string displayName);
        HostConfigurator SetServiceName(string serviceName);
    }
}
