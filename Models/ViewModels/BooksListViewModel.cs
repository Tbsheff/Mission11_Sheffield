using System.Collections;

namespace Mission10_Sheffield.Models.ViewModels;

public class BooksListViewModel
{
        public IQueryable<Book> Books { get; set; }
        public PaginationInfo PaginationInfo { get; set; } = new PaginationInfo();
    
}