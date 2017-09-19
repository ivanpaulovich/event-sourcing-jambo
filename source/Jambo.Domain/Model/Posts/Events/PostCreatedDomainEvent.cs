using System;

namespace Jambo.Domain.Model.Posts.Events
{
public class PostCreatedDomainEvent : DomainEvent
{
    public Guid BlogId { get; private set; }
    public int BlogVersion { get; private set; }

    public PostCreatedDomainEvent(Guid aggregateRootId, int version,
        DateTime createdDate, Header header, Guid blogId, int blogVersion)
        : base(aggregateRootId, version, createdDate, header)
    {
        BlogId = blogId;
        BlogVersion = blogVersion;
    }

    public static PostCreatedDomainEvent Create(AggregateRoot aggregateRoot,
        Guid blogId, int blogVersion)
    {
        if (aggregateRoot == null)
            throw new ArgumentNullException("aggregateRoot");

        PostCreatedDomainEvent domainEvent = new PostCreatedDomainEvent(
            aggregateRoot.Id, aggregateRoot.Version, DateTime.UtcNow, null, blogId, blogVersion);

        return domainEvent;
    }
}
}
