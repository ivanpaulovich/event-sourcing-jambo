using Jambo.Application.Commands;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Application.CommandHandlers
{
    public class ExcluirBlogCommandHandler : IAsyncRequestHandler<ExcluirBlogCommand>
    {
        private readonly IBlogWriteOnlyRepository _blogWriteOnlyRepository;

        public ExcluirBlogCommandHandler(IBlogWriteOnlyRepository blogWriteOnlyRepository)
        {
            _blogWriteOnlyRepository = blogWriteOnlyRepository ??
                throw new ArgumentNullException(nameof(blogWriteOnlyRepository));
        }

        public async Task Handle(ExcluirBlogCommand message)
        {
            Blog blog = new Blog(message.Id);

            blog.Disable();

            _blogWriteOnlyRepository.PublishEvents(blog);

            await _blogWriteOnlyRepository
                .UnitOfWork
                .SaveChanges();
        }
    }
}
