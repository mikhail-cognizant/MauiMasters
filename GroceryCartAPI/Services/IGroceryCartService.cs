using GroceryCartAPI.Models;

namespace GroceryCartAPI.Services;

public interface IGroceryCartService
{
    GroceryItem GetProductById(int productId);
    void AddGroceryItems(IEnumerable<GroceryItem> groceries);
    void RemoveGroceryItems(IEnumerable<GroceryItem> groceries);
    CartTotals CalculateTotalPrice(IEnumerable<GroceryItem> groceryList);
}
