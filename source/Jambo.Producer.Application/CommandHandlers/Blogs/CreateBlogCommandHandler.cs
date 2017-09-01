using Jambo.Producer.Application.Commands;
using Jambo.Producer.Application.Commands.Blogs;
using Jambo.Domain.Model.Blogs;
using MediatR;
using System;
using System.Threading.Tasks;
using Jambo.ServiceBus;

namespace Jambo.Producer.Application.CommandHandlers.Blogs
{
    public class CreatePostCommandHandler : IAsyncRequestHandler<CreateBlogCommand, Guid>
    {
        private readonly IBusWriter _serviceBus;

        public CreatePostCommandHandler(IBusWriter serviceBus)
        {
            _serviceBus = serviceBus ?? 
                throw new ArgumentNullException(nameof(serviceBus));
        }

        public async Task<Guid> Handle(CreateBlogCommand message)
        {
            Blog blog = new Blog();
            blog.Start();
            blog.UpdateUrl(message.Url);

            await _serviceBus.Publish(blog.GetEvents(), message.CorrelationId);

            return blog.Id;
        }
    }
}
