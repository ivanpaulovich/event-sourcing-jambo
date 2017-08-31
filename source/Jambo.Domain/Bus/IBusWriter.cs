using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Domain.ServiceBus
{
    public interface IBusWriter : IDisposable
    {
        Task Publish(DomainEvent _event);
        Task Publish(IEnumerable<DomainEvent> events, Guid correlationId);
    }
}
