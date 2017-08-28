using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Domain.ServiceBus
{
    public interface IServiceBus : IDisposable
    {
        Task Publish(DomainEvent _event);
        Task Publish(IEnumerable<DomainEvent> events, Guid correlationId);
        ProcessDomainEventDelegate OnReceive { get; set; }
        void Listen();
    }
}
