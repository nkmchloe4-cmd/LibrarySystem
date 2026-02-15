using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.Classes
{
    public class LoanManager // Handles all loan operations
    {
        private const int LoanLengthDays = 14;

        private readonly BookCatalog _bookCatalog;
        private readonly MemberRegistry _memberRegistry;

        // Internal list of active loans
        private readonly List<Loan> _loans = new();

        public LoanManager(BookCatalog bookCatalog, MemberRegistry memberRegistry)
        {
            _bookCatalog = bookCatalog;
            _memberRegistry = memberRegistry;
        }

        // Creates a new loan
        public Loan CreateLoan(string isbn, string memberId)
        {
            var book = _bookCatalog.FindBookByISBN(isbn);
            if (book == null)
                throw new Exception("Book not found.");

            var member = _memberRegistry.FindMemberById(memberId);
            if (member == null)
                throw new Exception("Member not found.");

            if (!book.IsAvailable)
                throw new Exception("Book is already loaned.");

            DateTime loanDate = DateTime.Now;
            DateTime dueDate = loanDate.AddDays(LoanLengthDays);

            var loan = new Loan(book, member, loanDate, dueDate);

            member.AddLoan(loan);
            _loans.Add(loan);

            book.IsAvailable = false;

            return loan;
        }

        // Returns a book and closes the loan
        public void ReturnBook(string isbn)
        {
            var loan = _loans.FirstOrDefault(l => l.Book.ISBN == isbn);
            if (loan == null)
                throw new Exception("Loan not found.");

            loan.ReturnDate = DateTime.Now;
            loan.Book.IsAvailable = true;

            _loans.Remove(loan);
        }

        // Returns all active loans
        public IEnumerable<Loan> GetAllLoans()
        {
            return _loans;
        }
    }
}
