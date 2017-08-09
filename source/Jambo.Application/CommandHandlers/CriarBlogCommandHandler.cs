using Jambo.Application.Commands;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;
using System;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers
{
    public class CriarBlogCommandHandler : IAsyncRequestHandler<CriarBlogCommand>
    {
        private readonly IBlogWriteOnlyRepository _blogWriteOnlyRepository;

        public CriarBlogCommandHandler(IBlogWriteOnlyRepository blogWriteOnlyRepository)
        {
            _blogWriteOnlyRepository = blogWriteOnlyRepository ?? 
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }

        public async Task Handle(CriarBlogCommand message)
        {
            Blog blog = new Blog(message.Url);

            _blogWriteOnlyRepository.PublishEvents(blog);

            await _blogWriteOnlyRepository
                .UnitOfWork
                .SaveChanges();
        }
    }
}
