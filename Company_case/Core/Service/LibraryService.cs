using Company_case.Core.Domain;
using Company_case.Core.Interface;

namespace Company_case.Core.Service;

public class LibraryService : ILibraryService
{
    private readonly ILibraryRepository _libraryRepository;
    
    public LibraryService(ILibraryRepository libraryRepository)
    {
        _libraryRepository = libraryRepository;
    }
    public List<Book> GetAllBooks()
    {
        var books = _libraryRepository.GetAllBooks();
        return books;
    }

    public IEnumerable<Book> GetBooksById(string id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetBooksByTitle(string title)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetBooksByAuthor(string author)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetBooksByGenre(string genreName)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetBooksByPrice(float price)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetBooksByPublishDate(DateTime date)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> GetBooksByDescription(string description)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Book> SearchBooks(string searchText)
    {
        var books = _libraryRepository.GetAllBooks();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            return books;
        }
        return books.Where(book => 
            (book.Id !=null && book.Id.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
            (book.Author !=null && book.Author.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
            (book.Title != null && book.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase)) ||
            (book.Genre != null && book.Genre.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
             (book.Description != null && book.Description.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
              book.Price.ToString().Contains(searchText) ||
              book.Publish_date.ToString("yyyy-MM-dd").Contains(searchText)
              ))).ToList();
    }



    public List<Book> SearchAdvanced(string title, string author, string genre, string id, string description, string price, string publish_date)
{
    IEnumerable<Book> books = _libraryRepository.GetAllBooks();

    // 1. Hantera Titel (Dela upp sökorden)
    if (!string.IsNullOrWhiteSpace(title))
    {
        // Ta bort stjärnor och dela upp meningen i ord
        var searchTerms = title.Replace("*", "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var term in searchTerms)
        {
            // För varje ord lägger vi till ett filter. 
            // Detta blir i SQL: WHERE Title LIKE '%ord1%' AND Title LIKE '%ord2%'
            books = books.Where(b => b.Title != null && b.Title.Contains(term, StringComparison.OrdinalIgnoreCase));
        }
    }

    // 2. Hantera Författare (Samma logik - fixar "Eva Cortes" vs "Cortes, Eva")
    if (!string.IsNullOrWhiteSpace(author))
    {
        var searchTerms = author.Replace("*", "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var term in searchTerms)
        {
            books = books.Where(b => b.Author != null && b.Author.Contains(term, StringComparison.OrdinalIgnoreCase));
        }
    }

    // 3. Genre (Ofta ett enda ord, men vi kan köra samma logik för säkerhets skull)
    if (!string.IsNullOrWhiteSpace(genre))
    {
        var term = genre.Replace("*", "").Trim();
        books = books.Where(b => b.Genre != null && b.Genre.Contains(term, StringComparison.OrdinalIgnoreCase));
    }

    // 4. ID (Exakt sökning eller delsträng, rensa stjärnor)
    if (!string.IsNullOrWhiteSpace(id))
    {
        var term = id.Replace("*", "").Trim();
        books = books.Where(b => b.Id != null && b.Id.Contains(term, StringComparison.OrdinalIgnoreCase));
    }

    // 5. Beskrivning (Dela upp orden här också för maximal träffsäkerhet)
    if (!string.IsNullOrWhiteSpace(description))
    {
        var searchTerms = description.Replace("*", "").Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        foreach (var term in searchTerms)
        {
            books = books.Where(b => b.Description != null && b.Description.Contains(term, StringComparison.OrdinalIgnoreCase));
        }
    }
// 6. Pris
    if (!string.IsNullOrWhiteSpace(price))
    {
        if (decimal.TryParse(price, out decimal priceValue))
        {
            books = books.Where(b => b.Price.ToString().Contains(price, StringComparison.OrdinalIgnoreCase));
        }
    }

// 7. Publiceringsdatum (söker på delsträngar i datumet, t.ex. "2000" eller "2000-10")
    if (!string.IsNullOrWhiteSpace(publish_date))
    {
        var term = publish_date.Replace("*", "").Trim();
        books = books.Where(b => b.Publish_date.ToString("yyyy-MM-dd").Contains(term, StringComparison.OrdinalIgnoreCase));
    }

    return books.ToList();
}
}