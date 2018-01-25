namespace Jambo.Domain.Model.Posts
{
    public class Title
    {
        public string Text { get; private set; }

        public Title(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new TitleShouldNotBeEmptyException("The 'Title' field is required");

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
