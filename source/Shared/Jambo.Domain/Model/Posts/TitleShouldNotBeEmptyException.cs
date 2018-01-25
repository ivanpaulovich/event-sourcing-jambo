namespace Jambo.Domain.Model.Posts
{
    using Jambo.Domain.Exceptions;

    public class TitleShouldNotBeEmptyException : DomainException
    {
        public TitleShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
