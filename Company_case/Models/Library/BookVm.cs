using System.ComponentModel.DataAnnotations;
using Company_case.Core.Domain;

namespace Company_case.Models.Library;

public class BookVm
{
    [ScaffoldColumn(false)]
    public string Id { get; set; }
    public string Author { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
    public DateTime Publish_date { get; set; }
    public string Description { get; set; }

    public static BookVm FromBook(Book book)
    {
        return new BookVm()
        {
            Id = book.Id,
            Author = book.Author,
            Title = book.Title,
            Genre = book.Genre,
            Price = book.Price,
            Publish_date = book.Publish_date,
            Description = book.Description

        };  
    }
    
}