using System;
using System.Collections.Generic;
using System.Text;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Blogs.Events;
using Jambo.Domain.Model;

namespace Jambo.Domain.Exceptions
{
    public class TransactionConflictException : JamboException
    {
        private AggregateRoot aggregateRoot;
        private DomainEvent message;

        public TransactionConflictException()
        { }

        public TransactionConflictException(string message)
            : base(message)
        { }

        public TransactionConflictException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public TransactionConflictException(AggregateRoot aggregateRoot, DomainEvent message)
        {
            this.aggregateRoot = aggregateRoot;
            this.message = message;
        }
    }
}
