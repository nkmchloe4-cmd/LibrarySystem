using LibrarySystem.Classes;

class Program
{
    static void Main(string[] args)
    {
        var library = new Library();

        // Example data
        library.BookCatalog.AddBook(new Book("The Lord of the Rings", "J.R.R. Tolkien", "978-91-0-012345-6", 1954));
        library.BookCatalog.AddBook(new Book("The Hobbit", "J.R.R. Tolkien", "978-91-0-065432-1", 1937));
        library.BookCatalog.AddBook(new Book("Harry Potter", "J.K. Rowling", "978-91-0-098765-4", 1997));


        library.MemberRegistry.AddMember(new Member("Anna Andersson", "M001", "anna@mail.com"));
        library.MemberRegistry.AddMember(new Member("Bob Karlsson", "M002", "bob@mail.com"));
        library.MemberRegistry.AddMember(new Member("Alice", "M003", "alice@mail.com"));



        while (true)
        {
            Console.WriteLine("\n=== Library System ===");
            Console.WriteLine("1. Show all books");
            Console.WriteLine("2. Search book");
            Console.WriteLine("3. Loan book");
            Console.WriteLine("4. Return book");
            Console.WriteLine("5. Show members");
            Console.WriteLine("6. Statistics");
            Console.WriteLine("7. Sort books by title");
            Console.WriteLine("8. Sort books by year");
            Console.WriteLine("0. Exit");
            Console.Write("Choose option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ShowAllBooks(library);
                    break;

                case "2":
                    SearchBooks(library);
                    break;

                case "3":
                    LoanBook(library);
                    break;

                case "4":
                    ReturnBook(library);
                    break;

                case "5":
                    ShowMembers(library);
                    break;

                case "6":
                    ShowStatistics(library);
                    break;
                case "7":
                    SortBooksByTitle(library);
                    break;

                case "8":
                    SortBooksByYear(library);
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Please type only options in menu.");
                    break;
            }
        }
    }

    static void ShowAllBooks(Library library)
    {
        Console.WriteLine("\nAll books:");
        foreach (var book in library.BookCatalog.GetAllBooks())
        {
            Console.WriteLine(book.GetInfo());
        }
    }

    static void SearchBooks(Library library)
    {
        Console.Write("\nSearch term: ");
        string term = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(term))
        {
            Console.WriteLine("Search term cannot be empty.");
            return;
        }

        var results = library.BookCatalog
            .GetAllBooks()
            .Where(b => b.Matches(term))
            .ToList();

        if (results.Count == 0)
        {
            Console.WriteLine("\nNo books found matching your search.");
            return;
        }

        Console.WriteLine("\nSearch results:");
        foreach (var book in results)
        {
            Console.WriteLine(book.GetInfo());
        }
    }


    static void LoanBook(Library library)
    {
        Console.Write("\nEnter ISBN: ");
        string isbn = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(isbn))
        {
            Console.WriteLine("ISBN cannot be empty.");
            return;
        }

        Console.Write("Enter member ID: ");
        string memberId = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(memberId))
        {
            Console.WriteLine("Member ID cannot be empty.");
            return;
        }

        try
        {
            var loan = library.LoanManager.CreateLoan(isbn, memberId);

            Console.WriteLine($"\nThe book \"{loan.Book.Title}\" has been loaned to {loan.Member.Name}.");
            Console.WriteLine($"Return date: {loan.DueDate:yyyy-MM-dd}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    static void ReturnBook(Library library)
    {
        Console.Write("\nEnter ISBN: ");
        string isbn = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(isbn))
        {
            Console.WriteLine("ISBN cannot be empty.");
            return;
        }

        try
        {
            library.LoanManager.ReturnBook(isbn);
            Console.WriteLine("The book has been returned.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }


    static void ShowMembers(Library library)
    {
        Console.WriteLine("\nMembers:");
        foreach (var member in library.MemberRegistry.GetAllMembers())
        {
            Console.WriteLine(member.GetInfo());
        }
    }

    static void ShowStatistics(Library library)
    {
        int totalBooks = library.BookCatalog.GetAllBooks().Count();
        int availableBooks = library.BookCatalog.GetAllBooks().Count(b => b.IsAvailable);
        int loanedBooks = totalBooks - availableBooks;

        int totalMembers = library.MemberRegistry.GetAllMembers().Count();
        int activeLoans = library.LoanManager.GetAllLoans().Count();

        Console.WriteLine("\n=== Statistics ===");
        Console.WriteLine($"Total books: {totalBooks}");
        Console.WriteLine($"Available books: {availableBooks}");
        Console.WriteLine($"Loaned books: {loanedBooks}");
        Console.WriteLine($"Total members: {totalMembers}");
        Console.WriteLine($"Active loans: {activeLoans}");
    }

    static void SortBooksByTitle(Library library)
    {
        Console.WriteLine("\nBooks sorted by title:");
        foreach (var book in library.SortBooksByTitle())
        {
            Console.WriteLine(book.GetInfo());
        }
    }

    static void SortBooksByYear(Library library)
    {
        Console.WriteLine("\nBooks sorted by year:");
        foreach (var book in library.SortBooksByYear())
        {
            Console.WriteLine(book.GetInfo());
        }
    }



}
