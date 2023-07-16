using MauiMasters.Services;

namespace MauiMasters;

public partial class ThankYou : ContentPage
{
    private readonly IGroceryService _groceryService;


    public ThankYou(IGroceryService groceryService)
	{
		InitializeComponent();
        _groceryService = groceryService;
    }

    protected override async void OnAppearing()
    {
        await Task.Delay(5000);

        await _groceryService.ClearCart();

        await Shell.Current.GoToAsync("//MainPage");
    }
}