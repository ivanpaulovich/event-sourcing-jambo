namespace Jambo.Domain.UnitTests
{
    using Jambo.Domain.Model.Posts;
    using Xunit;

    public class ValueObjectsTests
    {
        [Fact]
        public void Empty_Title()
        {
            //
            // Arrange
            string empty = string.Empty;

            //
            // Act and Assert
            Assert.Throws<TitleShouldNotBeEmptyException>(
                () => Title.Create(empty));
        }

        [Fact]
        public void Valid_Title()
        {
            //
            // Arrange
            string valid = "An Good Title";

            //
            // Act
            Title title = Title.Create(valid);

            //
            // Assert
            Assert.Equal(valid, title.Text);
        }

        [Fact]
        public void Empty_Content()
        {
            //
            // Arrange
            string empty = string.Empty;

            //
            // Act and Assert
            Assert.Throws<ContentShouldNotBeEmptyException>(
                () => Content.Create(empty));
        }

        [Fact]
        public void Valid_Content()
        {
            //
            // Arrange
            string valid = "An Good Title";

            //
            // Act
            Content content = Content.Create(valid);

            //
            // Assert
            Assert.Equal(valid, content.Text);
        }
    }
}
