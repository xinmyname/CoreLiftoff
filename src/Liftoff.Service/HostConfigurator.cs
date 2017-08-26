namespace Liftoff.Service
{
    public interface HostConfigurator {
        HostConfigurator SetDescription(string description);
        HostConfigurator SetDisplayName(string displayName);
        HostConfigurator SetServiceName(string serviceName);
    }
}
