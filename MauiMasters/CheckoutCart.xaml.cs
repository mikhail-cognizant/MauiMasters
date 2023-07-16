namespace MauiMasters;

public partial class CheckoutCart : ContentPage
{
    private readonly CheckoutCartViewModel _vm;

    public CheckoutCart(CheckoutCartViewModel vm)
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
        await Shell.Current.GoToAsync("//ThankYou");
    }
}