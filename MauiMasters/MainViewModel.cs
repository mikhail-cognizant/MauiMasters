using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiMasters;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<GroceryItem> GroceryList { get; set; } = new ObservableCollection<GroceryItem>
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
    private GroceryItem? selectedGroceryItem;

    [RelayCommand]
    private void IncrementQuantity(GroceryItem groceryItem)
    {
        SelectedGroceryItem = groceryItem;
        groceryItem.Quantity++;
        CalculatePrice();
    }

    [RelayCommand]
    private void DecrementQuantity(GroceryItem groceryItem)
    {
        SelectedGroceryItem = groceryItem;

        if (groceryItem.Quantity == 0) return;       
        groceryItem.Quantity--;
        CalculatePrice();
    }

    private const decimal vatrate = .12M;
    private void CalculatePrice()
    {        
        SubTotal = GroceryList.Sum(g => g.Price * g.Quantity);
        Vat = SubTotal * vatrate;
        TotalPrice = SubTotal + Vat;
    }

    [ObservableProperty]
    private decimal subTotal;
    [ObservableProperty]
    private decimal vat;
    [ObservableProperty]
    private decimal totalPrice;
}
