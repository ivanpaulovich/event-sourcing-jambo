using Jambo.Domain.Model;

namespace Jambo.ServiceBus
{
    public delegate void MessageReceived(DomainEvent domainEvent);
}
