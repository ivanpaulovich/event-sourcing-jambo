namespace Jambo.ServiceBus
{
    public delegate void EventReceivedDelegate(string topic, string key, string value);
}
