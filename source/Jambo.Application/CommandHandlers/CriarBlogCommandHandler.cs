using Jambo.Application.Commands;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers
{
    public class CriarBlogCommandHandler : IAsyncRequestHandler<CriarBlogCommand>
    {
        private readonly IBlogEventRepository _blogEventRepository;

        public CriarBlogCommandHandler(IBlogEventRepository blogEventRepository)
        {
            _blogEventRepository = blogEventRepository ?? 
                throw new ArgumentNullException(nameof(blogEventRepository));
        }

        public async Task Handle(CriarBlogCommand message)
        {
            Blog blog = new Blog();
            blog.DefinirUrl(message.Url);

            await _blogEventRepository.PublishEvents(blog);

            await _blogEventRepository
                .UnitOfWork
                .SaveChanges();
        }
    }
}
