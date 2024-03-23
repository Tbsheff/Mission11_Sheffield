namespace Mission10_Sheffield.Models;

public class EfBookstorerepository : IBookstoreRepository
{
    private BookstoreContext _context;
    
    public EfBookstorerepository(BookstoreContext context)
    {
        _context = context;
    }
    
    public IQueryable<Book> Books { get; }
    
}