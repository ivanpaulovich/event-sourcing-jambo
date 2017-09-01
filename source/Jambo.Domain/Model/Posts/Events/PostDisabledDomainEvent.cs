namespace Jambo.Domain.Model.Posts.Events
{
    public class PostDisabledDomainEvent : DomainEvent
    {
        public PostDisabledDomainEvent()
        {

        }

        public PostDisabledDomainEvent(AggregateRoot aggregateRoot)
            : base(aggregateRoot)
        {

        }
    }
}
