using GroceryCartAPI.Models;

namespace GroceryCartAPI.Services;

public class GroceryCartService : IGroceryCartService
{
    private static List<GroceryItem>? groceryItems;

    public GroceryCartService()
    {
        InitializeList();
    }

    private void InitializeList()
    {
        if (groceryItems == null)
        {
            groceryItems = new List<GroceryItem>()
            {
                new GroceryItem()
                {
                    Id = 1,
                    ItemName = "Banana",
                    Price = 15
                },
                new GroceryItem()
                {
                    Id = 2,
                    ItemName = "Pear",
                    Price = 50
                },
                new GroceryItem()
                {
                    Id = 3,
                    ItemName = "Apple",
                    Price = 35
                }
            };
        }
    }

    public GroceryItem GetProductById(int productId)
    {
        var groceryItem = groceryItems!.FirstOrDefault(g => g.Id == productId);
        if (groceryItem is not null)
            return groceryItem;

        throw new KeyNotFoundException("Product not found");
    }

    public void AddGroceryItems(IEnumerable<GroceryItem> groceries)
    {
        groceryItems!.AddRange(groceries); 
    }

    public void RemoveGroceryItems(IEnumerable<GroceryItem> groceries)
    {
        foreach (var groceryItem in groceries)
        {
            var item = groceryItems!.FirstOrDefault(g => g.Id == groceryItem.Id);
            if (item is not null)
            {
                groceryItems!.Remove(item);
            }
        }
    }
}
