using Jambo.Application.IntegrationEvents.Events;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using Jambo.KafkaBus;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.Commands
{
    public class CriarBlogCommandHandler : IAsyncRequestHandler<CriarBlogCommand>
    {
        private readonly IEventBus _eventBus;

        public CriarBlogCommandHandler(IEventBus eventBus)
        {
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }

        public async Task Handle(CriarBlogCommand message)
        {
            Blog blog = new Blog(message.Url);

            IntegrationEvent evento = new BlogCriadoIntegrationEvent(blog.Url); 
            await _eventBus.Publish(evento);
        }
    }
}
