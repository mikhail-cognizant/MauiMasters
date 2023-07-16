namespace Common;

public class CartLineItem
{
    public GroceryItemDto? GroceryItem { get; set; }
    public int Quantity { get; set; }
    public decimal BasePrice { get; set; }
    public decimal Tax { get; set; }
    public decimal Price => Quantity * (BasePrice + Tax);
}
