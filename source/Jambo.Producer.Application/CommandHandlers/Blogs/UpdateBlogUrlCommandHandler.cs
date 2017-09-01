using MediatR;
using System;
using System.Threading.Tasks;
using Jambo.Producer.Application.Commands;
using Jambo.Producer.Application.Commands.Blogs;
using Jambo.Producer.Application.Commands.Posts;
using Jambo.ServiceBus;
using Jambo.Domain.Model.Blogs;

namespace Jambo.Producer.Application.CommandHandlers.Blogs
{
    public class UpdateBlogUrlCommandHandler : IAsyncRequestHandler<UpdateBlogUrlCommand>
    {
        private readonly IBusWriter _serviceBus;
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;

        public UpdateBlogUrlCommandHandler(
            IBusWriter serviceBus,
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
