using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiMasters;

public partial class MainViewModel : ObservableObject
{
    public IEnumerable<GroceryItem> GroceryList { get; set; } = new[]
    {
        new GroceryItem
        { 
            Name = "Apple",
            Description = "A is for Apple",
            Price = 12.50M,
            ImageUrl = "apple.jpg"
        },
        new GroceryItem
        {
            Name = "Banana",
            Description = "B is for Banana",
            Price = 7.15M,
            ImageUrl = "banana.jpg"
        },
        new GroceryItem
        {
            Name = "Orange",
            Description = "O is for Orange",
            Price = 13.70M,
            ImageUrl = "orange.jpg"
        },
        new GroceryItem
        {
            Name = "Grapes",
            Description = "G is for Grapes",
            Price = 20.10M,
            ImageUrl = "grapes.jpg"
        },
        new GroceryItem
        {
            Name = "Strawberry",
            Description = "S is for Strawberry",
            Price = 4.20M,
            ImageUrl = "strawberry.jpg"
        },
        new GroceryItem
        {
            Name = "Melon",
            Description = "M is for Melon",
            Price = 20.30M,
            ImageUrl = "melon.jpg"
        }
    };

    [ObservableProperty]
    private GroceryItem selectedGroceryItem;


    public ObservableCollection<GroceryItem> GroceryBasket { get; set; } = new();
    [RelayCommand]
    private void AddGroceryItem(GroceryItem groceryItem)
    {
        GroceryBasket.Add(groceryItem);

        BasketCount = GroceryBasket.Count();
        TotalPrice = GroceryBasket.Sum(g => g.Price);
    }

    [ObservableProperty]
    private decimal totalPrice;
    [ObservableProperty]
    private int basketCount;
}
