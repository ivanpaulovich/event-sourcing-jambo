using Jambo.Domain.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.ServiceBus
{
    public interface IBusWriter : IDisposable
    {
        Task Publish(DomainEvent _event);
        Task Publish(IEnumerable<DomainEvent> events, Guid correlationId);
    }
}
