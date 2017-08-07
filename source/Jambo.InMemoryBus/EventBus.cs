using Jambo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MediatR;

namespace Jambo.InMemoryBus
{
    public class EventBus : IServiceBus
    {
        private readonly Queue<INotification> _messageQueue;
        private readonly IMediator _mediator;

        public EventBus(IMediator mediator)
        {
            _messageQueue = new Queue<INotification>();
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
                    INotification @event = _messageQueue.Dequeue();

                    await _mediator.Send(null);
                }
            }
        }

        public async Task Publish(INotification @event)
        {
            await Task.Run(() => _messageQueue.Enqueue(@event));
        }
    }
}
