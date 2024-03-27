namespace Mission10_Sheffield.Models;

public class EfBookstoreRepository : IBookstoreRepository
{
    private BookstoreContext _context;
    
    public EfBookstoreRepository(BookstoreContext context)
    {
        _context = context;
    }
    
    public IQueryable<Book> Books => _context.Books;
    
}