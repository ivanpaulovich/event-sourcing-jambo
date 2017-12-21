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
    public class DisablePostCommandHandler : IAsyncRequestHandler<DisablePostCommand>
    {
        private readonly IPublisher bus;
        private readonly IPostReadOnlyRepository postReadOnlyRepository;

        public DisablePostCommandHandler(
            IPublisher bus,
            IPostReadOnlyRepository postReadOnlyRepository)
        {
            this.bus = bus ??
                throw new ArgumentNullException(nameof(bus));
            this.postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
        }

        public async Task Handle(DisablePostCommand command)
        {
            Post post = await postReadOnlyRepository.GetPost(command.Id);
            post.Disable();

            await bus.Publish(post.GetEvents(), command.Header);
        }
    }
}
