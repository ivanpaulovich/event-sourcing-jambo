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
        private readonly IBlogWriteOnlyRepository _blogRepository;
        private readonly IMediator _mediator;

        public BlogCriadoDomainEventHandler(IMediator mediator, IBlogWriteOnlyRepository blogRepository)
        {
            _blogRepository = blogRepository ?? throw new ArgumentNullException(nameof(blogRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Handle(BlogCriadoDomainEvent notification)
        {
            await Task.Delay(100);
        }
    }
}
