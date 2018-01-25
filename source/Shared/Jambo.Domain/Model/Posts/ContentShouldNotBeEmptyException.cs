namespace Jambo.Domain.Model.Posts
{
    using Jambo.Domain.Exceptions;

    public class ContentShouldNotBeEmptyException : DomainException
    {
        public ContentShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
