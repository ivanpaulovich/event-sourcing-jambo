using Jambo.Producer.Application.Commands;
using Jambo.Producer.Application.Commands.Blogs;
using Jambo.Producer.Application.Commands.Posts;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using MediatR;
using System;
using System.Threading.Tasks;
using Jambo.Domain.ServiceBus;

namespace Jambo.Producer.Application.CommandHandlers.Posts
{
    public class PublishPostCommandHandler : IAsyncRequestHandler<PublishPostCommand>
    {
        private readonly IPublisher bus;
        private readonly IPostReadOnlyRepository postReadOnlyRepository;

        public PublishPostCommandHandler(
            IPublisher bus,
            IPostReadOnlyRepository postReadOnlyRepository)
        {
            this.bus = bus ??
                throw new ArgumentNullException(nameof(bus));
            this.postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
        }

        public async Task Handle(PublishPostCommand message)
        {
            Post post = await postReadOnlyRepository.GetPost(message.Id);
            post.Publish();

            await bus.Publish(post.GetEvents(), message.Header);
        }
    }
}
