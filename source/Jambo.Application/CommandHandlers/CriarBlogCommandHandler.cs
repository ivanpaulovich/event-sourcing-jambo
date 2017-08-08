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
        private readonly IEntityFactory _entityFactory;
        private readonly IServiceBus _serviceBus;

        public CriarBlogCommandHandler(IServiceBus serviceBus, IEntityFactory entityFactory)
        {
            _serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));
            _entityFactory = entityFactory ?? throw new ArgumentNullException(nameof(serviceBus));
        }

        public async Task Handle(CriarBlogCommand message)
        {
            Blog blog = new Blog(message.Url);

            blog.Attach(_serviceBus);
            blog.Notify();

            await _serviceBus.Publish();
        }
    }
}
