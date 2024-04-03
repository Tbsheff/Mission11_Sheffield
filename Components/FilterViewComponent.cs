using Microsoft.AspNetCore.Mvc;
using Mission10_Sheffield.Models;

namespace Mission10_Sheffield.Components;

public class FilterViewComponent : ViewComponent
{
    
    private IBookstoreRepository _repository;
    
    public FilterViewComponent(IBookstoreRepository repository)
    {
        _repository = repository;
    }
    
    public IViewComponentResult Invoke()
    {
        var categories = _repository.Books
            .Select(b => b.Category)
            .Distinct()
            .OrderBy(g => g);
        
        return View(categories);
    }
}