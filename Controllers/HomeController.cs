using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission10_Sheffield.Models;
using Mission10_Sheffield.Models.ViewModels;

namespace Mission10_Sheffield.Controllers;

public class HomeController : Controller
{
    private IBookstoreRepository _repository;
    public int PageSize = 10;

    public HomeController(IBookstoreRepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index(int pageNum = 1)
    {
        
        var blah = new BooksListViewModel
        {
            Books = _repository.Books
                .OrderBy(b => b.BookId)
                .Skip((pageNum - 1) * PageSize)
                .Take(PageSize),

            PaginationInfo = new PaginationInfo
            {
                CurrentPage = pageNum,
                ItemsPerPage = PageSize,
                TotalNumItems = _repository.Books.Count()
            }
        };
        
        return View(blah);
    }
    
}

