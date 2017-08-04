using Jambo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MediatR;

namespace Jambo.InMemoryBus
{
    public class EventBus : IEventBus
    {
        private readonly Queue<IntegrationEvent> _messageQueue;
        private readonly IMediator _mediator;

        public EventBus(IMediator mediator)
        {
            _messageQueue = new Queue<IntegrationEvent>();
            _mediator = mediator;

            Task.Run(() => Listen());
        }

        public async Task Listen()
        {
            while (true)
            {
                if (_messageQueue.Count() == 0)
                    await Task.Delay(1000);
                else
                {
                    IntegrationEvent @event = _messageQueue.Dequeue();

                    await _mediator.Send(@event);
                }
            }
        }

        public async Task Publish(IntegrationEvent @event)
        {
            await Task.Run(() => _messageQueue.Enqueue(@event));
        }
    }
}
