using Jambo.Application.Commands;
using Jambo.Application.Commands.Blogs;
using Jambo.Application.Commands.Posts;
using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Aggregates.Posts;
using Jambo.Domain.ServiceBus;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers.Posts
{
    public class CreatePostCommandHandler : IAsyncRequestHandler<CreatePostCommand, Guid>
    {
        private readonly IServiceBus _serviceBus;
        private readonly IPostReadOnlyRepository _blogReadOnlyRepository;

        public CreatePostCommandHandler(
            IServiceBus serviceBus,
            IPostReadOnlyRepository blogReadOnlyRepository)
        {
            _serviceBus = serviceBus ??
                throw new ArgumentNullException(nameof(serviceBus));
            _blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
        }

        public async Task<Guid> Handle(CreatePostCommand message)
        {
            Post post = new Post();
            post.Start(message.BlogId);            
            post.UpdateContent(message.Title, message.Content);

            await _serviceBus.Publish(post.GetEvents());

            return post.Id;
        }
    }
}
