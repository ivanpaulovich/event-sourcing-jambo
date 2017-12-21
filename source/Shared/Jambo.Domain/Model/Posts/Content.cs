namespace Jambo.Domain.Model.Posts
{
    using Jambo.Domain.Exceptions;

    public class Content
    {
        public string Text { get; private set; }

        public Content(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new DomainException("The content field is required");

            this.Text = text;
        }

        public static Content Create(string text)
        {
            return new Content(text);
        }

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
