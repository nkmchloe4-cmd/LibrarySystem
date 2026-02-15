namespace LibrarySystem.Classes
{
    public class Library
    {
        public BookCatalog BookCatalog { get; }
        public MemberRegistry MemberRegistry { get; }
        public LoanManager LoanManager { get; }

        public Library()
        {
            BookCatalog = new BookCatalog();
            MemberRegistry = new MemberRegistry();
            LoanManager = new LoanManager(BookCatalog, MemberRegistry);
        }

        // Unified search for both books and members
        public IEnumerable<ISearchable> Search(string searchTerm)
        {
            List<ISearchable> results = new List<ISearchable>();

            results.AddRange(BookCatalog.GetAllBooks());

            results.AddRange(MemberRegistry.GetAllMembers());

            // Filters with Matches()
            return results.Where(item => item.Matches(searchTerm));
        }

        // Sort books alphabetically
        public IEnumerable<Book> SortBooksByTitle()
        {
            return BookCatalog.GetAllBooks()
                .OrderBy(b => b.Title);
        }

        // Sort books by year
        public IEnumerable<Book> SortBooksByYear()
        {
            return BookCatalog.GetAllBooks()
                .OrderBy(b => b.PublishedYear);
        }

        public int GetTotalBooks() => BookCatalog.GetAllBooks().Count();

        // Number of borrowed books
        public int GetBorrowedBooksCount() => 
            BookCatalog.GetAllBooks().Count(b => !b.IsAvailable);

        // Member with most active loans
        public Member? GetMostActiveBorrower()
        {
            return MemberRegistry.GetAllMembers()
                .OrderByDescending(m => m.ActiveLoansCount)
                .FirstOrDefault();
        }
    }
}
