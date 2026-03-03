using Company_case.Core.Domain;

namespace Company_case.Core.Interface;

public interface ILibraryService
{
    List<Book> GetAllBooks();
    IEnumerable<Book> GetBooksById(String id);
    IEnumerable<Book> GetBooksByTitle(string title);
    IEnumerable<Book> GetBooksByAuthor(string author);
    IEnumerable<Book> GetBooksByGenre(string genreName);
    IEnumerable<Book> GetBooksByPrice(float price);
    IEnumerable<Book> GetBooksByPublishDate(DateTime date);
    IEnumerable<Book> GetBooksByDescription(string description);
    IEnumerable<Book> SearchBooks(string searchString);
    List<Book> SearchAdvanced(string title, string author, string genre, string id, string description, string price, string publish_date);
}