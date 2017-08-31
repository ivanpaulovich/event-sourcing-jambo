namespace Jambo.Domain.ServiceBus
{
    public delegate void ProcessDomainEventDelegate(string topic, string key, string value);
}
