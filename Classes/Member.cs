using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.Classes
{
    public class Member : ISearchable
    {
        public string Name { get; set; }
        public string MemberId { get; }
        public string Email { get; set; }
        public DateTime MemberSince { get; }

        private readonly List<Loan> _loans;
        public int ActiveLoansCount => _loans.Count(l => !l.IsReturned);



        public Member(string name, string memberId, string email) 
        {
            Name = name;
            MemberId = memberId;
            Email = email;
            MemberSince = DateTime.Now;

            _loans = new List<Loan>();
        }

        public void AddLoan(Loan loan) //Method that adds a loan to the member
        { 
            _loans.Add(loan); 
        }


        public string GetInfo()
        {
            return $"ID: {MemberId}, Name: {Name}, Email: {Email}, Member Since: {MemberSince:yyyy-MM-dd}, Active Loans: {_loans.Count}";
        }


        public bool Matches(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return false;

            searchTerm = searchTerm.ToLower();

            return Name.ToLower().Contains(searchTerm)
                || Email.ToLower().Contains(searchTerm)
                || MemberId.ToLower().Contains(searchTerm);
        }



    }
}
