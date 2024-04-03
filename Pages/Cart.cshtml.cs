using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission10_Sheffield.Infrastructure;
using Mission10_Sheffield.Models;

namespace Mission10_Sheffield.Pages;

public class CartModel(IBookstoreRepository repository) : PageModel
{
    public Cart? Cart { get; set; }

    public void OnGet()
    {
        Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
    }

    public void OnPost(int bookId)
    {
        var selectedBook = repository.Books
            .FirstOrDefault(p => p.BookId == bookId);

        if (selectedBook != null)
        {
            Cart = HttpContext.Session.GetJson<Cart>("Cart") ?? new Cart();
            Cart.AddItem(selectedBook, 1);
            HttpContext.Session.SetJson("Cart", Cart);
        }
    }
}