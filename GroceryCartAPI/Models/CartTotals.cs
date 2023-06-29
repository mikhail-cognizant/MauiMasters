namespace GroceryCartAPI.Models;

public class CartTotals
{
    public List<CartLinetem> Items { get; set; } = new();
    public decimal TotalPrice => Items is not null ? Items.Sum(i => i.Price) : 0;
}
