namespace Mission10_Sheffield.Models;

public class Cart
{
    public List<CartLine> Lines { get; set; } = new();

    public virtual void AddItem(Book book, int quantity)
    {
        var line = Lines
            .FirstOrDefault(p => p.Book.BookId == book.BookId);

        if (line == null)
            Lines.Add(new CartLine
            {
                Book = book,
                Quantity = quantity
            });
        else
            line.Quantity += quantity;
    }

    public virtual void RemoveLine(Book book)
    {
        Lines.RemoveAll(l =>
            l.Book.BookId == book.BookId);
    }

    public decimal ComputeTotalValue()
    {
        return (decimal)Lines.Sum(e => e.Book.Price * e.Quantity);
    }

    public virtual void Clear()
    {
        Lines.Clear();
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Book Book { get; set; } = new();
        public int Quantity { get; set; }
    }
}