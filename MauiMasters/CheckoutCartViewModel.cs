using Common;
using CommunityToolkit.Mvvm.ComponentModel;
using MauiMasters.Services;

namespace MauiMasters;

public partial class CheckoutCartViewModel : ObservableObject
{
    private readonly IGroceryService _groceryService;

    [ObservableProperty]
    private CartTotals cartSummary;

    public CheckoutCartViewModel(IGroceryService groceryService)
    {
        _groceryService = groceryService;
    }

    public async Task Initialize()
    {
        CartSummary = await _groceryService.GetCartTotal();
    }
}
