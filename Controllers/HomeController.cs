using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission10_Sheffield.Models;
using Mission10_Sheffield.Models.ViewModels;

namespace Mission10_Sheffield.Controllers;

public class HomeController : Controller
{
    private IBookstoreRepository _repository;
    public int PageSize = 3;

    public HomeController(IBookstoreRepository repository)
    {
        _repository = repository;
    }
    

    public IActionResult Index(int pageNum = 1, string category = "All")
    {
        var blah = new BooksListViewModel
        {
            Books = _repository.Books
                .Where(b => category == "All" || b.Category == category)
                .OrderBy(b => b.BookId)
                .Skip((pageNum - 1) * PageSize)
                .Take(PageSize),

            PaginationInfo = new PaginationInfo
            {
                CurrentPage = pageNum,
                ItemsPerPage = PageSize,
                TotalNumItems = category == "All" ?
                    _repository.Books.Count() :
                    _repository.Books.Where(b => b.Category == category).Count()
            },
            CurrentCategory = category
        };
        
        return View(blah);
    }

    
}

