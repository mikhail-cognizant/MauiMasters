namespace Common;

public class CartTotals
{
    public List<CartLineItem> Items { get; set; } = new();
    public decimal SubTotal => Items is not null ? Items.Sum(i => i.BasePrice) : 0;
    public decimal VatTotal => Items is not null ? Items.Sum(i => i.Tax) : 0;
    public decimal TotalPrice => Items is not null ? Items.Sum(i => i.Price) : 0;
}
