using Jambo.Application.Commands;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers
{
    public class CriarBlogCommandHandler : IAsyncRequestHandler<CriarBlogCommand>
    {
        private readonly IServiceBus _serviceBus;

        public CriarBlogCommandHandler(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));
        }

        public async Task Handle(CriarBlogCommand message)
        {
            Blog blog = new Blog(message.Url);

            foreach (var domainEvent in blog.DomainEvents)
            {
                await _serviceBus.Publish(domainEvent);
            }
        }
    }
}
