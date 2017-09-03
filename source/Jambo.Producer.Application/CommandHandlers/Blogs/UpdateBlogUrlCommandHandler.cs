using MediatR;
using System;
using System.Threading.Tasks;
using Jambo.Producer.Application.Commands.Blogs;
using Jambo.ServiceBus;
using Jambo.Domain.Model.Blogs;

namespace Jambo.Producer.Application.CommandHandlers.Blogs
{
    public class UpdateBlogUrlCommandHandler : IAsyncRequestHandler<UpdateBlogUrlCommand>
    {
        private readonly IPublisher bus;
        private readonly IBlogReadOnlyRepository blogReadOnlyRepository;

        public UpdateBlogUrlCommandHandler(
            IPublisher bus,
            IBlogReadOnlyRepository blogReadOnlyRepository)
        {
            this.bus = bus ??
                throw new ArgumentNullException(nameof(bus));
            this.blogReadOnlyRepository = blogReadOnlyRepository ??
                throw new ArgumentNullException(nameof(blogReadOnlyRepository));
        }

        public async Task Handle(UpdateBlogUrlCommand command)
        {
            Blog blog = await blogReadOnlyRepository.GetBlog(command.Id);
            blog.UpdateUrl(Url.Create(command.Url));

            await bus.Publish(blog.GetEvents(), command.Header);
        }
    }
}
