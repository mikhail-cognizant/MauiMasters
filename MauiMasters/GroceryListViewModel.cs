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
        var groceryItems = await _groceryService.GetGroceryItems();
        if(groceryItems.Any())
        {
            foreach (var groceryItem in groceryItems)
            { 
                GroceryList.Add(groceryItem);
            }
        }
    }

    public ObservableCollection<GroceryItem> GroceryList { get; set; } = new();

    [ObservableProperty]
    private GroceryItem? selectedGroceryItem;

    [RelayCommand]
    private void IncrementQuantity()
    {
        SelectedGroceryItem.Quantity++;
        CalculatePrice();
    }

    [RelayCommand]
    private void DecrementQuantity()
    {
        if (SelectedGroceryItem.Quantity == 0) return;
        SelectedGroceryItem.Quantity--;
        CalculatePrice();
    }

    [RelayCommand]
    private async Task AddToCart()
    {
        await _groceryService.AddGroceryItem(SelectedGroceryItem);
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
