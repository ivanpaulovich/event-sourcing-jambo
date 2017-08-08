using Jambo.Domain.SeedWork;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public class Post : Entity
    {
        public Post(IServiceBus serviceBus) : base(serviceBus)
        {
        }

        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
