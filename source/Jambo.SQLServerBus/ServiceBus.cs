using Jambo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.SQLServerBus
{
    public class ServiceBus : IServiceBus
    {
        private Queue<IEvent> _domainEvents;
        public Queue<IEvent> DomainEvents => _domainEvents;

        public void Add(IEvent _event)
        {
            _domainEvents = _domainEvents ?? new Queue<IEvent>();
            _domainEvents.Enqueue(_event);
        }

        public ServiceBus(string connecionString)
        {

        }

        public async Task Listen()
        {
            await Task.Delay(100);
        }

        public Task Publish(IEvent _event)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
