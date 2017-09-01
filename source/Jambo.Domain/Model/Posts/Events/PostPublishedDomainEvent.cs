namespace Jambo.Domain.Model.Posts.Events
{
    public class PostPublishedDomainEvent : DomainEvent
    {
        public PostPublishedDomainEvent()
        {

        }

        public PostPublishedDomainEvent(AggregateRoot aggregateRoot)
            : base(aggregateRoot)
        {
        }
    }
}
