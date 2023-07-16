using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiMasters.Services;
using System.Collections.ObjectModel;

namespace MauiMasters;

public partial class GroceryListViewModel : ObservableObject
{
    private readonly IGroceryService _groceryService;

    public GroceryListViewModel(IGroceryService groceryService)
    {
        _groceryService = groceryService;
    }

    public async Task Initialize()
    {
        Reset();
        var groceryItems = await _groceryService.GetGroceryItems();
        if(groceryItems.Any())
        {
            foreach (var groceryItem in groceryItems)
            { 
                GroceryList.Add(groceryItem);
            }
        }
    }

    private void Reset()
    {
        GroceryList.Clear();
        SelectedGroceryItem = default;
        TotalPrice = 0;
    }

    public ObservableCollection<GroceryItem> GroceryList { get; set; } = new();

    [ObservableProperty]
    private GroceryItem? selectedGroceryItem;

    [RelayCommand]
    private void IncrementQuantity()
    {
        SelectedGroceryItem.Quantity++;
    }

    [RelayCommand]
    private void DecrementQuantity()
    {
        if (SelectedGroceryItem.Quantity == 0) return;

        SelectedGroceryItem.Quantity--;

        if (SelectedGroceryItem.Quantity == 0)
        {
            if (SelectedGroceryItem.IsAddedToCart)
            {
                OnPropertyChanging(nameof(SelectedGroceryItem));
                SelectedGroceryItem.ActionText = "Remove from Cart";
                OnPropertyChanged(nameof(SelectedGroceryItem));
            }
        };
    }

    [RelayCommand]
    private async Task AddToCart()
    {
        if (SelectedGroceryItem.Quantity > 0)
        {
            await _groceryService.AddGroceryItem(SelectedGroceryItem);
        }
        else
        {
            await RemoveFromCart();
        }
        
        CalculatePrice();
    }

    [RelayCommand]
    private async Task RemoveFromCart()
    {
        await _groceryService.DeleteGroceryItem(SelectedGroceryItem);
        CalculatePrice();
    }

    private static decimal taxRate = .12M;
    private void CalculatePrice()
    {
        TotalPrice = GroceryList.Sum(g => (g.Price + (g.Price * taxRate)) * g.Quantity);
    }

    [ObservableProperty]
    private decimal totalPrice;
}
