using LibraryApi.interfaces;
using LibraryApi.Models;

public class BookRepository : IBookRepository
{
    private List<Book> _books = new List<Book>
    {
        new Book { Id = 1, Title = "Clean Code: A Handbook of Agile Software Craftsmanship", Author = "Robert C. Martin" },
        new Book { Id = 2, Title = "Code Complete: A Practical Handbook of Software Construction", Author = "Steve McConnell" },
        new Book { Id = 3, Title = "Design Patterns: Elements of Reusable Object-Oriented Software", Author = "Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides" },
        new Book { Id = 4, Title = "The Pragmatic Programmer: Your Journey to Mastery", Author = "Andrew Hunt and David Thomas" },
        new Book { Id = 5, Title = "Introduction to Algorithms", Author = "Thomas Cormen, Clifford Stein, Ronald Rivest, Charles Leiserson" },
        new Book { Id = 6, Title = "Structure and Interpretation of Computer Programs (SICP)", Author = "Harold Abelson, Gerald Jay Sussman, Julie Sussman" },
        new Book { Id = 7, Title = "The Clean Coder: A Code of Conduct for Professional Programmers", Author = "Robert C. Martin" },
        new Book { Id = 8, Title = "Cracking the Coding Interview", Author = "Gayle Laakmann McDowell" },
        new Book { Id = 9, Title = "Effective Java", Author = "Joshua Bloch" },
        new Book { Id = 10, Title = "Deep Learning", Author = "Ian Goodfellow, Yoshua Bengio, Aaron Courville" },

    };

    public IEnumerable<Book> GetAllBooks()
    {
        return _books;
    }

    public Book GetBookById(int id)
    {
        return _books.FirstOrDefault(b => b.Id == id);
    }

    public void AddBook(Book book)
    {
        if (book != null)
        {
            // Asignar un nuevo ID al libro. Esto es solo para simulación; en una base de datos real, esto se generaría automáticamente.
            book.Id = _books.Max(b => b.Id) + 1;
            _books.Add(book);
        }
    }

    public void UpdateBook(Book book)
    {
        var bookToUpdate = _books.FirstOrDefault(b => b.Id == book.Id);
        if (bookToUpdate != null)
        {
            bookToUpdate.Title = book.Title;
            bookToUpdate.Author = book.Author;
        }
    }

    public void DeleteBook(int id)
    {
        var bookToRemove = _books.FirstOrDefault(b => b.Id == id);
        if (bookToRemove != null)
        {
            _books.Remove(bookToRemove);
        }
    }
}
