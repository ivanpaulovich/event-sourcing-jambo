using Jambo.Application.Commands;
using Jambo.Application.Commands.Blogs;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using Jambo.Domain.ServiceBus;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers.Blogs
{
    public class DisableBlogCommandHandler : IAsyncRequestHandler<DisableBlogCommand>
    {
        private readonly IBusWriter _serviceBus;
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;

        public DisableBlogCommandHandler(
            IBusWriter serviceBus,
            IBlogReadOnlyRepository blogReadOnlyRepository)
        {
            _serviceBus = serviceBus ??
                throw new ArgumentNullException(nameof(serviceBus));
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
        }

        public async Task Handle(DisableBlogCommand message)
        {
            Blog blog = await _blogReadOnlyRepository.GetBlog(message.Id);
            blog.Disable();

            await _serviceBus.Publish(blog.GetEvents(), message.CorrelationId);
        }
    }
}
