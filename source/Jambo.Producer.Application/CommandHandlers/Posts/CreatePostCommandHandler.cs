using Jambo.Producer.Application.Commands;
using Jambo.Producer.Application.Commands.Blogs;
using Jambo.Producer.Application.Commands.Posts;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using Jambo.ServiceBus;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Posts
{
    public class CreatePostCommandHandler : IAsyncRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IPublisher bus;
        private readonly IPostReadOnlyRepository postReadOnlyRepository;
        private readonly IBlogReadOnlyRepository blogReadOnlyRepository;

        public CreatePostCommandHandler(
            IPublisher bus,
            IPostReadOnlyRepository postReadOnlyRepository,
            IBlogReadOnlyRepository blogReadOnlyRepository)
        {
            this.bus = bus ??
                throw new ArgumentNullException(nameof(bus));
            this.postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
            this.blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
        }

        public async Task<Guid> Handle(CreatePostCommand command)
        {
            Blog blog = await blogReadOnlyRepository.GetBlog(command.BlogId);

            Post post = Post.Create();
            post.Start(command.BlogId, blog.Version);            
            post.UpdateContent(command.Title, command.Content);

            await bus.Publish(post.GetEvents(), command.CorrelationId);

            return post.Id;
        }
    }
}
