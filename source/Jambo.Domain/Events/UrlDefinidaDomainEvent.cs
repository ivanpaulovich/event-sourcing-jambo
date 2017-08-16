using System;

namespace Jambo.Domain.Events
{
    public class UrlDefinidaDomainEvent : DomainEvent
    {
        public string Url { get; set; }
        public UrlDefinidaDomainEvent(Guid aggregateRootId, int version, string url)
            :base(aggregateRootId, version)
        {
            Url = url;
        }
    }
}
