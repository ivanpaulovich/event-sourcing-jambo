using Jambo.Application.Commands;
using Jambo.Application.Commands.Blogs;
using Jambo.Application.Commands.Posts;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using Jambo.Domain.ServiceBus;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers.Posts
{
    public class CreatePostCommandHandler : IAsyncRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IBusWriter _serviceBus;
        private readonly IPostReadOnlyRepository _postReadOnlyRepository;
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;

        public CreatePostCommandHandler(
            IBusWriter serviceBus,
            IPostReadOnlyRepository postReadOnlyRepository,
            IBlogReadOnlyRepository blogReadOnlyRepository)
        {
            _serviceBus = serviceBus ??
                throw new ArgumentNullException(nameof(serviceBus));
            _postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
        }

        public async Task<Guid> Handle(CreatePostCommand message)
        {
            Blog blog = await _blogReadOnlyRepository.GetBlog(message.BlogId);

            Post post = new Post();
            post.Start(message.BlogId, blog.Version);            
            post.UpdateContent(message.Title, message.Content);

            await _serviceBus.Publish(post.GetEvents(), message.CorrelationId);

            return post.Id;
        }
    }
}
