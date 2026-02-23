using LibrarySystem.Classes;
using Xunit;

namespace LibrarySystem.Tests
{
    public class SearchTests
    {
        [Theory]
        [InlineData("Tolkien", true)]
        [InlineData("tolkien", true)]
        [InlineData("Rowling", false)]
        public void Book_Matches_ShouldFindByAuthor(string searchTerm, bool expected)
        {
            // Arrange
            var book = new Book("The Lord of the Rings", "J.R.R. Tolkien", "123", 1954);

            // Act
            var result = book.Matches(searchTerm);

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void Member_Matches_ShouldFindByName()
        {
            // Arrange
            var member = new Member("Anna Andersson", "M001", "anna@mail.com");

            // Act & Assert
            Assert.True(member.Matches("Anna"));
            Assert.False(member.Matches("Bob"));
        }
    }
}