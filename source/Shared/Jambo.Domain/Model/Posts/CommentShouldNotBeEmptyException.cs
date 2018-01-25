namespace Jambo.Domain.Model.Posts
{
    using Jambo.Domain.Exceptions;

    public class CommentShouldNotBeEmptyException : DomainException
    {
        public CommentShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
