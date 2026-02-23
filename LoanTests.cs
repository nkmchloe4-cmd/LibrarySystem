using LibrarySystem.Classes;
using Xunit;
using System;

namespace LibrarySystem.Tests
{
    public class LoanTests
    {
        [Fact]
        public void IsReturned_ShouldBeFalse_WhenReturnDateIsNull()
        {
            // Arrange
            var book = new Book("Testbok", "Författare", "67543212345-09", 1998);
            var member = new Member("John", "ad4536", "johnb@gmail.com");
            var loanDate = new DateTime(2024, 1, 1);
            var dueDate = new DateTime(2024, 1, 10);

            var loan = new Loan(book, member, loanDate, dueDate);

            // Act
            bool result = loan.IsReturned;

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsReturned_ShouldBeTrue_WhenReturnDateHasValue()
        {
            // Arrange
            var book = new Book("Testnovel", "Författare2", "675433457345-09", 1958);
            var member = new Member("Peter", "apo4536", "Gayverb@gmail.com");
            var loan = new Loan(book, member, DateTime.Now, DateTime.Now.AddDays(5));

            loan.ReturnDate = DateTime.Now;

            // Act
            bool result = loan.IsReturned;

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsOverdue_ShouldBeTrue_WhenDueDateHasPassed_AndNotReturned()
        {
            // Arrange
            var book = new Book("TestRoman", "Författare3", "67093212345-09", 1938);
            var member = new Member("Clyde", "klo4536", "Bonnieb@gmail.com");

            var loanDate = DateTime.Now.AddDays(-10);
            var dueDate = DateTime.Now.AddDays(-5);

            var loan = new Loan(book, member, loanDate, dueDate);

            // Act
            bool result = loan.IsOverdue;

            // Assert
            Assert.True(result);
        }
    }
}
