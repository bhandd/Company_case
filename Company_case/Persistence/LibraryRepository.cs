using System.Globalization;
using System.Xml.Linq;
using System.Xml.Serialization;
using Company_case.Core.Domain;
using Company_case.Core.Interface;
using Microsoft.AspNetCore.Hosting;

namespace Company_case.Persistence
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly string _filePath;

        public LibraryRepository(IWebHostEnvironment env)
        {
            _filePath = Path.Combine(
                env.ContentRootPath,
                "Data",
                "books.xml"
            );
        }

        public List<Book> GetAllBooks()
        {
            if(!File.Exists(_filePath))
                return new List<Book>();
            try
            {
                var doc = XDocument.Load(_filePath);
                return doc.Descendants("book").Select((x => new Book
                {
                    Id = x.Attribute("id")?.Value,
                    Author = x.Element("author")?.Value,
                    Title = x.Element("title")?.Value,
                    Genre = x.Element("genre")?.Value,
                    Price = decimal.TryParse(x.Element("price")?.Value, NumberStyles.Any, CultureInfo.InvariantCulture,
                        out var price)
                        ? price : 0,
                    Publish_date = DateTime.TryParse(x.Element("publish_date")?.Value, out DateTime date)
                        ? date : DateTime.MinValue,
                    Description = x.Element("description")?.Value,
                })).ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
    
    // FRAMTIDA SQL-IMPLEMENTATION 
    /*
    // Vi behöver injicera databaskontexten här
    // private readonly LibraryContext _context;

    public IQueryable<Book> GetAllBooks()
    {
        // Detta returnerar en fråga till databasen, ingen data hämtas förrän filtrering är klar
        return _context.Books;
    }
    */
}