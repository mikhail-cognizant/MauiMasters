using Common;

namespace MauiMasters.Services;

public interface IGroceryService
{
    Task<IEnumerable<GroceryItem>> GetGroceryItems();
    Task<bool> AddGroceryItem(GroceryItem item);
    Task<bool> DeleteGroceryItem(GroceryItem item);
    Task<CartTotals> GetCartTotal();
    Task<bool> ClearCart();
}
