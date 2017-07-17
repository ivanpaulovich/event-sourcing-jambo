using Jambo.Application.Commands;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Application.DomainEventHandlers.BlogCriado
{
    public class BlogCriadoDomainEventHandler
        : IAsyncNotificationHandler<BlogCriadoDomainEvent>
    {
        private readonly IBlogWriteOnlyRepository _orderRepository;
        private readonly IMediator _mediator;

        public BlogCriadoDomainEventHandler(IMediator mediator, IBlogWriteOnlyRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public Task Handle(BlogCriadoDomainEvent notification)
        {
            throw new NotImplementedException();
        }
    }
}
