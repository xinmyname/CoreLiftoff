namespace Liftoff.Service {

    public interface HostConfigurator {

        ServiceConfiguration Configuration { get; }

        HostConfigurator SetDescription(string description);
        HostConfigurator SetDisplayName(string displayName);
        HostConfigurator SetServiceName(string serviceName);
    }
}
