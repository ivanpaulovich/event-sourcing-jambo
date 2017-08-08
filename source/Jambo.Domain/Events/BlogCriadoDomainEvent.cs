using Jambo.Domain.SeedWork;

namespace Jambo.Domain.Events
{
    public class BlogCriadoDomainEvent : IEvent
    {
        public string Url { get; set; }

        public BlogCriadoDomainEvent(string url)
        {
            Url = url;
        }
    }
}
