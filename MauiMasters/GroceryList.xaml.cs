namespace MauiMasters;

public partial class GroceryList : ContentPage
{
	private readonly GroceryListViewModel _vm;

    public GroceryList(GroceryListViewModel vm)
	{
		InitializeComponent();
		_vm = vm;
		BindingContext = _vm;
	}

	protected override async void OnAppearing()
	{
		await _vm.Initialize();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//CartSummary");
    }
}