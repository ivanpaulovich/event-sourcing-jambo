using Jambo.Domain.SeedWork;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public class Post : Entity
    {
        public string Title { get; private set; }
        public string Content { get; private set; }

        public int BlogId { get; private set; }
        public Blog Blog { get; private set; }
    }
}
