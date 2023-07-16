﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace MauiMasters;

public partial class MainViewModel : ObservableObject
{
    public ObservableCollection<GroceryItem> GroceryList { get; set; } = new ObservableCollection<GroceryItem>
    {
        
        
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
