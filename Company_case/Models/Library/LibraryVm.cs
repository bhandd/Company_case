namespace Company_case.Models.Library;

public class LibraryVm
{
   public List<BookVm> Books { get; set; }
   public string SearchId {get; set;}
   public string SearchTitle { get; set; }
   public string SearchAuthor { get; set; }
   public string SearchGenre { get; set; }
   public string SearchPrice { get; set; }
   public string SearchPublishDate { get; set; }
   public string SearchDescription { get; set; }
    
}