namespace GroceryCartAPI.Models;

public class CartLinetem
{
    public GroceryItem? GroceryItem { get; set; }
    public int Quantity { get; set; }
    public decimal BasePrice { get; set; }
    public decimal Tax { get; set; }
    public decimal Price => Quantity * (BasePrice + Tax);
}
