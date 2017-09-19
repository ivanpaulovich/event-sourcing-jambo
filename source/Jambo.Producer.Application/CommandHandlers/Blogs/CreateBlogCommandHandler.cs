using Jambo.Producer.Application.Commands;
using Jambo.Producer.Application.Commands.Blogs;
using Jambo.Domain.Model.Blogs;
using MediatR;
using System;
using System.Threading.Tasks;
using Jambo.ServiceBus;

namespace Jambo.Producer.Application.CommandHandlers.Blogs
{
public class CreatePostCommandHandler : IAsyncRequestHandler<CreateBlogCommand, Guid>
{
    private readonly IPublisher bus;

    public CreatePostCommandHandler(IPublisher bus)
    {
        this.bus = bus ?? throw new ArgumentNullException(nameof(bus));
    }

    public async Task<Guid> Handle(CreateBlogCommand command)
    {
        Blog blog = Blog.Create();
        blog.Start();
        blog.UpdateUrl(Url.Create(command.Url));

        await bus.Publish(blog.GetEvents(), command.Header);

        return blog.Id;
    }
}
}
