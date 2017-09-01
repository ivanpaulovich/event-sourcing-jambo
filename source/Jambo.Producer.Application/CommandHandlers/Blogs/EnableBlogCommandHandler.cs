using MediatR;
using System;
using System.Threading.Tasks;
using Jambo.Producer.Application.Commands.Blogs;
using Jambo.Domain.Model.Blogs;
using Jambo.ServiceBus;

namespace Jambo.Producer.Application.CommandHandlers.Blogs
{
    public class EnableBlogCommandHandler : IAsyncRequestHandler<EnableBlogCommand>
    {
        private readonly IPublisher bus;
        private readonly IBlogReadOnlyRepository blogReadOnlyRepository;

        public EnableBlogCommandHandler(
            IPublisher serviceBus,
            IBlogReadOnlyRepository blogReadOnlyRepository)
        {
            bus = serviceBus ??
                throw new ArgumentNullException(nameof(serviceBus));
            this.blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
        }

        public async Task Handle(EnableBlogCommand command)
        {
            Blog blog = await blogReadOnlyRepository.GetBlog(command.Id);
            blog.Enable();

            await bus.Publish(blog.GetEvents(), command.CorrelationId);
        }
    }
}
