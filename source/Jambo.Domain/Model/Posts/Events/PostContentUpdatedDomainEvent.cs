namespace Jambo.Domain.Model.Posts.Events
{
    public class PostContentUpdatedDomainEvent : DomainEvent
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public PostContentUpdatedDomainEvent()
        {

        }

        public PostContentUpdatedDomainEvent(AggregateRoot aggregateRoot,
            string title, string content)
            : base(aggregateRoot)
        {
            Title = title;
            Content = content;
        }
    }
}
