using Company_case.Core.Domain;
using Company_case.Core.Interface;
using Company_case.Models.Library;
using Microsoft.AspNetCore.Mvc;

namespace Company_case.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        // GET: LibraryController
        // public ActionResult Index(string searchString)
        // {
        //     IEnumerable<Book> books;
        //     if (string.IsNullOrEmpty(searchString))
        //     {
        //         books = _libraryService.GetAllBooks();
        //     }
        //     else
        //     {
        //         books = _libraryService.SearchBooks(searchString);
        //     }
        //     ViewData["CurrentFilter"] = searchString;
        //     return View(books); 
        // }
        
        public IActionResult Index()
        {
            List<Book> books = _libraryService.GetAllBooks();
            List<BookVm> bookVms = new List<BookVm>();
            foreach (Book book in books)
            {
                bookVms.Add(BookVm.FromBook(book));
            }
            LibraryVm libraryVm = new LibraryVm();
            libraryVm.Books = bookVms;
            return View(libraryVm);
        }
        
        public IActionResult Search(string searchTitle, string searchAuthor, string searchGenre, string searchId, string searchDescription, string searchPrice, string searchPublishDate)
        {
            List<Book> books = _libraryService.SearchAdvanced(searchTitle, searchAuthor, searchGenre, searchId, searchDescription, searchPrice, searchPublishDate);
    
            List<BookVm> bookVms = new List<BookVm>();
            foreach (Book book in books)
            {
                bookVms.Add(BookVm.FromBook(book));
            }
    
            LibraryVm libraryVm = new LibraryVm
            {
                Books = bookVms,
                SearchTitle = searchTitle,
                SearchAuthor = searchAuthor,
                SearchGenre = searchGenre,
                SearchId = searchId,
                SearchDescription = searchDescription,
                SearchPrice = searchPrice,
                SearchPublishDate = searchPublishDate
            };
    
            return View("Index", libraryVm);
        }



       

     
    }
}
