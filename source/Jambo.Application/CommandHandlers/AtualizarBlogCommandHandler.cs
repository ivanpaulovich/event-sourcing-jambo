using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;
using System;
using System.Threading.Tasks;
using Jambo.Application.Commands;
using Jambo.Domain.SeedWork;

namespace Jambo.Application.CommandHandlers
{
    public class AtualizarBlogCommandHandler : IAsyncRequestHandler<AtualizarBlogCommand>
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IServiceBus _serviceBus;

        public AtualizarBlogCommandHandler(IServiceBus serviceBus, IEntityFactory entityFactory)
        {
            _serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));
            _entityFactory = entityFactory ?? throw new ArgumentNullException(nameof(serviceBus));
        }

        public async Task Handle(AtualizarBlogCommand message)
        {
            Blog blog = _entityFactory.Create<Blog>();

            blog.DefinirUrl(message.Url);

            blog.Notify();

            await _serviceBus.Publish();
        }
    }
}
