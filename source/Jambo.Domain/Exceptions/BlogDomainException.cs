using System;

namespace Jambo.Domain.Exceptions
{
    public class BlogDomainException : Exception
    {
        public BlogDomainException()
        { }

        public BlogDomainException(string message)
            : base(message)
        { }

        public BlogDomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
