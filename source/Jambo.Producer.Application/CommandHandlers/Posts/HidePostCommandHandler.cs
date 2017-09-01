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
    public class HidePostCommandHandler : IAsyncRequestHandler<HidePostCommand>
    {
        private readonly IBusWriter _serviceBus;
        private readonly IPostReadOnlyRepository _postReadOnlyRepository;

        public HidePostCommandHandler(
            IBusWriter serviceBus,
            IPostReadOnlyRepository postReadOnlyRepository)
        {
            _serviceBus = serviceBus ??
                throw new ArgumentNullException(nameof(serviceBus));
            _postReadOnlyRepository = postReadOnlyRepository ??
                throw new ArgumentNullException(nameof(postReadOnlyRepository));
        }

        public async Task Handle(HidePostCommand message)
        {
            Post post = await _postReadOnlyRepository.GetPost(message.Id);
            post.Hide();

            await _serviceBus.Publish(post.GetEvents(), message.CorrelationId);
        }
    }
}
