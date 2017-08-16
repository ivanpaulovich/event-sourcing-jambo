using Jambo.Domain.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Domain.SeedWork
{
    public interface IServiceBus : IDisposable
    {
        Task Publish(IEvent _event);
        Task Publish(IEnumerable<IEvent> _event);
        ProcessDomainEventDelegate OnReceive { get; set; }
        void Listen();
    }
}
