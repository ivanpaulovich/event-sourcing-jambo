using Jambo.Domain.Model;

namespace Jambo.Domain.Exceptions
{
    public class TransactionConflictException : JamboException
    {
        public AggregateRoot AggregateRoot { get; private set; }
        public DomainEvent DomainEvent { get; private set; }

        public TransactionConflictException(AggregateRoot aggregateRoot, DomainEvent domainEvent)
        {
            this.AggregateRoot = aggregateRoot;
            this.DomainEvent = domainEvent;
        }
    }
}
