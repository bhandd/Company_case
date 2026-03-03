using Company_case.Core.Domain;

namespace Company_case.Core.Interface;

public interface ILibraryRepository
{
   List<Book> GetAllBooks();
    
   //IQueryable<Book> GetAllBooks();
}