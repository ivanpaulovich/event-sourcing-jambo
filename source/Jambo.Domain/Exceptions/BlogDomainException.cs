namespace Jambo.Domain.Exceptions
{
    public class BlogDomainException : JamboException
    {
        public string BusinessMessage { get; set; }

        public BlogDomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}
