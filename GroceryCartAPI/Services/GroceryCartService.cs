using Common;
using GroceryCartAPI.Models;

namespace GroceryCartAPI.Services;

public class GroceryCartService : IGroceryCartService
{
    private static List<GroceryItem> groceryItems = new();
    private static List<GroceryItem> groceryCart = new();
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
                new GroceryItem
                {
                    Id = 1,
                    Name = "Apple",
                    Description = "A is for Apple",
                    Price = 12.50M,
                    ImageUrl = "apple.jpg"
                },
                new GroceryItem
                {
                    Id = 2,
                    Name = "Banana",
                    Description = "B is for Banana",
                    Price = 7.15M,
                    ImageUrl = "banana.jpg"
                },
                new GroceryItem
                {
                    Id = 3,
                    Name = "Orange",
                    Description = "O is for Orange",
                    Price = 13.70M,
                    ImageUrl = "orange.jpg"
                },
                new GroceryItem
                {
                    Id = 4,
                    Name = "Grapes",
                    Description = "G is for Grapes",
                    Price = 20.10M,
                    ImageUrl = "grapes.jpg"
                },
                new GroceryItem
                {
                    Id = 5,
                    Name = "Strawberry",
                    Description = "S is for Strawberry",
                    Price = 4.20M,
                    ImageUrl = "strawberry.jpg"
                },
                new GroceryItem
                {
                    Id = 6,
                    Name = "Melon",
                    Description = "M is for Melon",
                    Price = 20.30M,
                    ImageUrl = "melon.jpg"
                },
                new GroceryItem()
                {
                    Id = 7,
                    Name = "Pear",
                    Price = 50
                },
                new GroceryItem()
                {
                    Id = 8,
                    Name = "Watermelon",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 9,
                    Name = "Orange",
                    Price = 3
                },
                new GroceryItem()
                {
                    Id = 10,
                    Name = "Grapes",
                    Price = 8
                },
                new GroceryItem()
                {
                    Id = 11,
                    Name = "Cherry",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 12,
                    Name = "Peach",
                    Price = 3
                },
                new GroceryItem()
                {
                    Id = 13,
                    Name = "Strawberry",
                    Price = 23
                },
                new GroceryItem()
                {
                    Id = 14,
                    Name = "Plum",
                    Price = 35
                },
                new GroceryItem()
                {
                    Id = 15,
                    Name = "Fig",
                    Price = 15
                },
                new GroceryItem()
                {
                    Id = 16,
                    Name = "Kiwi",
                    Price = 26
                },
                new GroceryItem()
                {
                    Id = 17,
                    Name = "Pineapple",
                    Price = 35
                },
                new GroceryItem()
                {
                    Id = 18,
                    Name = "Papaya",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 19,
                    Name = "Avocado",
                    Price = 9
                },
                new GroceryItem()
                {
                    Id = 20,
                    Name = "Apricot",
                    Price = 8
                },
                new GroceryItem()
                {
                    Id = 21,
                    Name = "Dragon fruit",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 22,
                    Name = "Carambola",
                    Price = 3
                },
                new GroceryItem()
                {
                    Id = 23,
                    Name = "Mango",
                    Price = 13
                },
                new GroceryItem()
                {
                    Id = 24,
                    Name = "Grapefruit",
                    Price = 14
                },
                new GroceryItem()
                {
                    Id = 25,
                    Name = "Lemon",
                    Price = 15
                },
                new GroceryItem()
                {
                    Id = 26,
                    Name = "Raspberry",
                    Price = 6
                },
                new GroceryItem()
                {
                    Id = 27,
                    Name = "Pomegranate",
                    Price = 23
                },
                new GroceryItem()
                {
                    Id = 28,
                    Name = "Guava",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 29,
                    Name = "Jackfruit",
                    Price = 3
                },
                new GroceryItem()
                {
                    Id = 30,
                    Name = "Durian",
                    Price = 5
                },
                new GroceryItem()
                {
                    Id = 31,
                    Name = "Lanzones",
                    Price = 7
                },
                new GroceryItem()
                {
                    Id = 32,
                    Name = "Coconut",
                    Price = 3
                },
                new GroceryItem()
                {
                    Id = 33,
                    Name = "Blueberry",
                    Price = 16
                },
                new GroceryItem()
                {
                    Id = 34,
                    Name = "Rambutan",
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
        groceryCart!.AddRange(groceries);
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

    public CartTotals CalculateTotalPrice()
    {
        var cartTotal = new CartTotals();
        //var groceryItemQuantities = groceryCart.GroupBy(g => g.Id)
        //    .ToDictionary(key => key.Key, value => value.Count());

        var cartLineItems = groceryCart.Select(g =>
        {
            var basePrice = g.Price;
            return new CartLineItem
            {
                GroceryItem = g.ToDto(),
                Quantity = g.Quantity,
                BasePrice = basePrice,
                Tax = basePrice * taxRate
            };
        });
        cartTotal.Items.AddRange(cartLineItems);

        return cartTotal;
    }
}
