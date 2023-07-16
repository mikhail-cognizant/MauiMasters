namespace MauiMasters.Services;

public interface IGroceryService
{
    Task<IEnumerable<GroceryItem>> GetGroceryItems();
    Task<bool> AddGroceryItem(GroceryItem item);
}
