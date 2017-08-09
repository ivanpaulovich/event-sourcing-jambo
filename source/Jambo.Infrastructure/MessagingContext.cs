using Jambo.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Infrastructure
{
    public class MessagingContext : IUnitOfWork
    {
        private readonly Queue<IEvent> _domainEvents;
        private readonly IServiceBus _serviceBus;

        public MessagingContext(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
            _domainEvents = new Queue<IEvent>();
        }

        public void Add(IEvent _event)
        {
            _domainEvents.Enqueue(_event);
        }

        public async Task SaveChanges()
        {
            while (_domainEvents.Count > 0)
            {
                IEvent _event = _domainEvents.Dequeue();
                await _serviceBus.Publish(_event);
            }
        }

        public void Dispose()
        {
            _serviceBus.Dispose();
        }
    }
}
