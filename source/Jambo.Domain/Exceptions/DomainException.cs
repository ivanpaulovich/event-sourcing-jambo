namespace Jambo.Domain.Exceptions
{
    public class DomainException : JamboException
    {
        public string BusinessMessage { get; set; }

        public DomainException(string businessMessage)
        {
            BusinessMessage = businessMessage;
        }
    }
}
