namespace MauiMasters.Services;

public interface IGroceryService
{
    Task<IEnumerable<GroceryItem>> GetGroceryItems();
    //Task<IEnumerable<GroceryItem>> AddGroceryItem(GroceryItem item);
}
