using LibrarySystem.Classes;
using Xunit;

namespace LibrarySystem.Tests
{
    public class LibraryStatisticsTests
    {
        [Fact]
        public void GetTotalBooks_ShouldReturnCorrectCount()
        {
            var library = new Library();

            library.BookCatalog.AddBook(new Book("A", "Author", "1", 2000));
            library.BookCatalog.AddBook(new Book("B", "Author", "2", 2001));

            Assert.Equal(2, library.GetTotalBooks());
        }

        [Fact]
        public void GetBorrowedBooksCount_ShouldReturnCorrectCount()
        {
            var library = new Library();

            var book1 = new Book("A", "Author", "1", 2000);
            var book2 = new Book("B", "Author", "2", 2001);

            library.BookCatalog.AddBook(book1);
            library.BookCatalog.AddBook(book2);

            // Add member
            library.MemberRegistry.AddMember(new Member("Test", "M001", "test@test.com"));

            // Loan book1
            library.LoanManager.CreateLoan("1", "M001");

            Assert.Equal(1, library.GetBorrowedBooksCount());
        }
    }
}