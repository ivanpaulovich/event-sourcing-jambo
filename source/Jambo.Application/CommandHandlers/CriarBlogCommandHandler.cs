using Jambo.Application.Commands;
using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.ServiceBus;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers
{
    public class CriarBlogCommandHandler : IAsyncRequestHandler<CreateBlogCommand>
    {
        private readonly IServiceBus _serviceBus;

        public CriarBlogCommandHandler(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus ?? 
                throw new ArgumentNullException(nameof(serviceBus));
        }

        public async Task Handle(CreateBlogCommand message)
        {
            Blog blog = new Blog();
            blog.UpdateUrl(message.Url);

            await _serviceBus.Publish(blog.GetEvents());
        }
    }
}
