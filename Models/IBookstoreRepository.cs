namespace Mission10_Sheffield.Models;

public interface IBookstoreRepository
{
    
    public IQueryable<Book> Books { get; }
}