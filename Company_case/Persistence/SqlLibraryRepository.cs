using Company_case.Core.Domain;
using Company_case.Core.Interface;


namespace Company_case.Persistence
{
    // Denna klass används inte nu, men är redo för när vi byter till SQL-databas.
    // Det enda vi behöver göra är att byta "LibraryRepository" mot "SqlLibraryRepository" i Program.cs.
    public class SqlLibraryRepository : ILibraryRepository
    {
        // En "mock" av en databaskoppling (Entity Framework)
        // private readonly ApplicationDbContext _context; 

        public SqlLibraryRepository(/* ApplicationDbContext context */)
        {
            // _context = context;
        }

        // Här är skillnaden: Vi returnerar IQueryable istället för en färdig lista.
        // Det betyder att ingen data hämtas förrän vi lägger på ett filter (WHERE).
        public List<Book> GetAllBooks()
        {
            // I en riktig databaslösning hade det sett ut så här:
            // return _context.Books; 
            
            throw new NotImplementedException("Denna körs när vi bytt till SQL!");
        }
        
        // För skalbarhet:
        // Metoden ovan returnerar egentligen IQueryable<Book> mot databasen.
        // Det gör att söksträngen "SELECT * FROM Books WHERE Title = 'X'" körs i SQL-servern
        // istället för att hämta 1 miljon böcker till serverns minne.
    }
}