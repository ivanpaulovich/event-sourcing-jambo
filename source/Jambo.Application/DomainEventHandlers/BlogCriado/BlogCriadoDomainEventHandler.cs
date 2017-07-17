using Jambo.Application.Commands;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Application.DomainEventHandlers.BlogCriado
{
    public class BlogCriadoDomainEventHandler
        : IRequestHandler<CriarBlogCommand, bool>
    {
        private readonly IBlogWriteOnlyRepository _orderRepository;
        private readonly IMediator _mediator;

        public BlogCriadoDomainEventHandler(IMediator mediator, IBlogWriteOnlyRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public bool Handle(CriarBlogCommand message)
        {
            return false;
        }
    }
}
