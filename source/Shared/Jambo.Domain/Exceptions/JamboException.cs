namespace Jambo.Domain.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class JamboException : Exception
    {
        public JamboException()
        { }

        public JamboException(string message)
            : base(message)
        { }

        public JamboException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
