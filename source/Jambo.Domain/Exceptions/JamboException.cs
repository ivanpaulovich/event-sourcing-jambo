using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Exceptions
{
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
