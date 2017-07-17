using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Application.Commands
{
    public class CriarBlogCommandHandler
        : IRequestHandler<CriarBlogCommand, bool>
    {
        private readonly IBlogWriteOnlyRepository _orderRepository;
        private readonly IMediator _mediator;

        public CriarBlogCommandHandler(IMediator mediator, IBlogWriteOnlyRepository blogRepository)
        {
            _orderRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public bool Handle(CriarBlogCommand message)
        {
            return false;
        }
    }
}
