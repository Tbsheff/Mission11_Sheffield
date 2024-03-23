using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission10_Sheffield.Models;

namespace Mission10_Sheffield.Controllers;

public class HomeController : Controller
{
    private EfBookstorerepository _repository;
    



    public HomeController(EfBookstorerepository repository)
    {
        _repository = repository;
    }

    public IActionResult Index()
    {
        return View();
    }
    
}