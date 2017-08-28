using MediatR;
using System;
using System.Threading.Tasks;
using Jambo.Application.Commands;
using Jambo.Domain.ServiceBus;
using Jambo.Domain.Aggregates.Blogs;
using Jambo.Application.Commands.Blogs;

namespace Jambo.Application.CommandHandlers.Blogs
{
    public class UpdateBlogUrlCommandHandler : IAsyncRequestHandler<UpdateBlogUrlCommand>
    {
        private readonly IServiceBus _serviceBus;
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;

        public UpdateBlogUrlCommandHandler(
            IServiceBus serviceBus,
            IBlogReadOnlyRepository blogReadOnlyRepository)
        {
            _serviceBus = serviceBus ??
                throw new ArgumentNullException(nameof(serviceBus));
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
        }

        public async Task Handle(UpdateBlogUrlCommand message)
        {
            Blog blog = await _blogReadOnlyRepository.GetBlog(message.Id);
            blog.UpdateUrl(message.Url);

            await _serviceBus.Publish(blog.GetEvents(), message.CorrelationId);
        }
    }
}
