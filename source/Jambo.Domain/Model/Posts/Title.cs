using Jambo.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Model.Posts
{
    public class Title
    {
        public string Text { get; private set; }

        public Title(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new BlogDomainException("The title field is required");

            this.Text = text;
        }

        public static Title Create(string text)
        {
            return new Title(text);
        }

        public override string ToString()
        {
            return Text.ToString();
        }
    }
}
