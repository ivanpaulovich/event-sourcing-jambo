namespace Jambo.Domain.ServiceBus
{
    public delegate void EventReceivedDelegate(string topic, string key, string value);
}
