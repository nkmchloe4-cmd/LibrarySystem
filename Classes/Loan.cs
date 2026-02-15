using System;
using System.Collections.Generic;
using System.Linq;
namespace LibrarySystem.Classes
{
    public class Loan
    {
        public Book Book { get; }
        public Member Member { get; }
        public DateTime LoanDate { get; }
        public DateTime DueDate { get; }
        public DateTime? ReturnDate { get; set; }

        public Loan(Book book, Member member, DateTime loanDate, DateTime dueDate ) 
        {
            Book = book;
            Member = member;
            LoanDate = loanDate;
            DueDate = dueDate;
            ReturnDate = null;
        }


        public bool IsReturned => ReturnDate != null;

        public bool IsOverdue => !IsReturned && DateTime.Now > DueDate;
    }
}
