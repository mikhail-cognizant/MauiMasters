using GroceryCartAPI.Models;

namespace GroceryCartAPI.Services;

public class GroceryCartService : IGroceryCartService
{
    private static List<GroceryItem> groceryItems = new();
    private static decimal taxRate = .12M;

    public GroceryCartService()
    {
        InitializeList();
    }

    private void InitializeList()
    {
        if (!groceryItems.Any())
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
                },
                new GroceryItem()
                {
                    Id = 4,
                    ItemName = "Watermelon",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 5,
                    ItemName = "Orange",
                    Price = 3
                },
                new GroceryItem()
                {
                    Id = 6,
                    ItemName = "Grapes",
                    Price = 8
                },
                new GroceryItem()
                {
                    Id = 7,
                    ItemName = "Cherry",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 8,
                    ItemName = "Peach",
                    Price = 3
                },
                new GroceryItem()
                {
                    Id = 9,
                    ItemName = "Strawberry",
                    Price = 23
                },
                new GroceryItem()
                {
                    Id = 10,
                    ItemName = "Plum",
                    Price = 35
                },
                new GroceryItem()
                {
                    Id = 11,
                    ItemName = "Fig",
                    Price = 15
                },
                new GroceryItem()
                {
                    Id = 12,
                    ItemName = "Kiwi",
                    Price = 26
                },
                new GroceryItem()
                {
                    Id = 13,
                    ItemName = "Pineapple",
                    Price = 35
                },
                new GroceryItem()
                {
                    Id = 14,
                    ItemName = "Papaya",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 15,
                    ItemName = "Avocado",
                    Price = 9
                },
                new GroceryItem()
                {
                    Id = 16,
                    ItemName = "Apricot",
                    Price = 8
                },
                new GroceryItem()
                {
                    Id = 17,
                    ItemName = "Dragon fruit",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 18,
                    ItemName = "Carambola",
                    Price = 3
                },
                new GroceryItem()
                {
                    Id = 19,
                    ItemName = "Mango",
                    Price = 13
                },
                new GroceryItem()
                {
                    Id = 20,
                    ItemName = "Grapefruit",
                    Price = 14
                },
                new GroceryItem()
                {
                    Id = 21,
                    ItemName = "Lemon",
                    Price = 15
                },
                new GroceryItem()
                {
                    Id = 22,
                    ItemName = "Raspberry",
                    Price = 6
                },
                new GroceryItem()
                {
                    Id = 23,
                    ItemName = "Pomegranate",
                    Price = 23
                },
                new GroceryItem()
                {
                    Id = 24,
                    ItemName = "Guava",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 25,
                    ItemName = "Jackfruit",
                    Price = 3
                },
                new GroceryItem()
                {
                    Id = 26,
                    ItemName = "Durian",
                    Price = 5
                },
                new GroceryItem()
                {
                    Id = 27,
                    ItemName = "Lanzones",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 28,
                    ItemName = "Coconut",
                    Price = 3
                },
                new GroceryItem()
                {
                    Id = 29,
                    ItemName = "Blueberry",
                    Price = 16
                },
                new GroceryItem()
                {
                    Id = 30,
                    ItemName = "Rambutan",
                    Price = 12
                }
            };
        }
    }

    public IEnumerable<GroceryItem> GetAllProducts()
    {
        return groceryItems;
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

    public CartTotals CalculateTotalPrice(IEnumerable<GroceryItem> groceryList)
    {
        var cartTotal = new CartTotals();
        var groceryItemQuantities = groceryList.GroupBy(g => g.Id)
            .ToDictionary(key => key.Key, value => value.Count());

        var cartLineItems = groceryList.DistinctBy(g => g.Id).Select(g =>
        {
            var basePrice = g.Price is not null ? g.Price.Value : 0;
            return new CartLinetem
            {
                GroceryItem = g,
                Quantity = groceryItemQuantities[g.Id],
                BasePrice = basePrice,
                Tax = basePrice * taxRate
            };
        });
        cartTotal.Items.AddRange(cartLineItems);

        return cartTotal;
    }
}
