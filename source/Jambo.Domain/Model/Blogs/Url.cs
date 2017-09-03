using Jambo.Domain.Exceptions;
using System.Runtime.Serialization;

namespace Jambo.Domain.Model.Blogs
{
    public class Url
    {
        public string Text { get; private set; }

        public Url(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new BlogDomainException("The url field is required");

            this.Text = text;
        }

        public static Url Create(string text)
        {
            return new Url(text);
        }

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
