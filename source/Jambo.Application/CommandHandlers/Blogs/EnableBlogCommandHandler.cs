using MediatR;
using System;
using System.Threading.Tasks;
using Jambo.Application.Commands;
using Jambo.Domain.ServiceBus;
using Jambo.Domain.Aggregates.Blogs;
using Jambo.Application.Commands.Blogs;
using Jambo.Domain.Aggregates.Posts;
using Jambo.Application.Commands.Posts;

namespace Jambo.Application.CommandHandlers.Blogs
{
    public class EnableBlogCommandHandler : IAsyncRequestHandler<EnableBlogCommand>
    {
        private readonly IServiceBus _serviceBus;
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;

        public EnableBlogCommandHandler(
            IServiceBus serviceBus,
            IBlogReadOnlyRepository blogReadOnlyRepository)
        {
            _serviceBus = serviceBus ??
                throw new ArgumentNullException(nameof(serviceBus));
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
        }

        public async Task Handle(EnableBlogCommand message)
        {
            Blog blog = await _blogReadOnlyRepository.GetBlog(message.Id);
            blog.Enable();

            await _serviceBus.Publish(blog.GetEvents(), message.CorrelationId);
        }
    }
}
