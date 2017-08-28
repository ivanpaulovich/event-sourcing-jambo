using Jambo.Application.Commands.Posts;
using Jambo.Domain.Aggregates.Blogs;
using Jambo.Domain.Aggregates.Posts;
using Jambo.Domain.ServiceBus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers.Posts
{
    public class CreateCommentCommandHandler : IAsyncRequestHandler<CreateCommentCommand, Guid>
    {
        private readonly IServiceBus _serviceBus;
        private readonly IPostReadOnlyRepository _postReadOnlyRepository;
        private readonly IBlogReadOnlyRepository _blogReadOnlyRepository;

        public CreateCommentCommandHandler(
            IServiceBus serviceBus,
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

        public async Task<Guid> Handle(CreateCommentCommand message)
        {
            Post post = await _postReadOnlyRepository.GetPost(message.PostId);

            Comment comment = new Comment(message.Comment);
            post.Comment(comment);

            await _serviceBus.Publish(post.GetEvents(), message.CorrelationId);

            return comment.Id;
        }
    }
}
