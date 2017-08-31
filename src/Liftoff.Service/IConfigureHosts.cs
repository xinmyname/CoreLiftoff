namespace Liftoff.Service {

    public interface IConfigureHosts {

        IConfigureHosts SetDescription(string description);
        IConfigureHosts SetDisplayName(string displayName);
        IConfigureHosts SetServiceName(string serviceName);
    }
}
