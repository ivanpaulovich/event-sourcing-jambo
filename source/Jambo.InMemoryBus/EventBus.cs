using Jambo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.InMemoryBus
{
    public class EventBus : IEventBus
    {
        private readonly Queue<IntegrationEvent> _messageQueue;

        public EventBus()
        {
            _messageQueue = new Queue<IntegrationEvent>();
        }

        public async Task Publish(IntegrationEvent @event)
        {
            await Task.Run(() => _messageQueue.Enqueue(@event));
        }

        public void ReadMessages()
        {
            while (true)
            {
                //if (_messageQueue.Count() == 0)
                //    Task.

                //IntegrationEvent @event = _messageQueue.Dequeue();


            }
        }
    }
}
