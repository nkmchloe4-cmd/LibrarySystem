namespace LibrarySystem.Classes
{
    public class BookCatalog
    {
        private readonly Dictionary<string, Book> _booksByIsbn = new();

        public void AddBook(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            _booksByIsbn[book.ISBN] = book;
        }

        // Finds a book by its ISBN, returns null if not found
        public Book? FindBookByISBN(string isbn)
        {
            _booksByIsbn.TryGetValue(isbn, out var book);
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _booksByIsbn.Values;
        }
    }
}
