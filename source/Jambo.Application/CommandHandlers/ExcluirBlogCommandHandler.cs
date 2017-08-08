using Jambo.Application.Commands;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers
{
    public class ExcluirBlogCommandHandler : IAsyncRequestHandler<ExcluirBlogCommand>
    {
        private readonly IEntityFactory _entityFactory;
        private readonly IServiceBus _serviceBus;

        public ExcluirBlogCommandHandler(IServiceBus serviceBus, IEntityFactory entityFactory)
        {
            _serviceBus = serviceBus ?? throw new ArgumentNullException(nameof(serviceBus));
            _entityFactory = entityFactory ?? throw new ArgumentNullException(nameof(serviceBus));
        }

        public async Task Handle(ExcluirBlogCommand message)
        {
            Blog blog = _entityFactory.Create<Blog>();

            blog.DefinirId(message.Id);

            await _serviceBus.Publish();
        }
    }
}
