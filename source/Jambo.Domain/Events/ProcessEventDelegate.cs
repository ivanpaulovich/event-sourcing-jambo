namespace Jambo.Domain.Events
{
    public delegate void ProcessDomainEventDelegate(string topic, int partition, long offSet, string value);
}
