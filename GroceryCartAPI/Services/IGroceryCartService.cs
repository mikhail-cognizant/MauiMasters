using Common;
using GroceryCartAPI.Models;

namespace GroceryCartAPI.Services;

public interface IGroceryCartService
{
    IEnumerable<GroceryItem> GetAllProducts();
    GroceryItem GetProductById(int productId);
    void AddGroceryItems(IEnumerable<GroceryItem> groceries);
    void RemoveGroceryItems(IEnumerable<GroceryItem> groceries);
    CartTotals CalculateTotalPrice();
    void ClearCart();
}
