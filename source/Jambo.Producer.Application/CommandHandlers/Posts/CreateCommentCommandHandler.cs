using Jambo.Producer.Application.Commands.Posts;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using Jambo.ServiceBus;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.CommandHandlers.Posts
{
    public class CreateCommentCommandHandler : IAsyncRequestHandler<CreateCommentCommand, Guid>
    {
        private readonly IPublisher bus;
        private readonly IPostReadOnlyRepository postReadOnlyRepository;
        private readonly IBlogReadOnlyRepository blogReadOnlyRepository;

        public CreateCommentCommandHandler(
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

        public async Task<Guid> Handle(CreateCommentCommand command)
        {
            Post post = await postReadOnlyRepository.GetPost(command.PostId);

            Comment comment = new Comment(command.Comment);
            post.Comment(comment);

            await bus.Publish(post.GetEvents(), command.Header);

            return comment.Id;
        }
    }
}
