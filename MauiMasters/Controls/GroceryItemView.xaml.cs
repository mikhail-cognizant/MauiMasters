using AndroidX.CardView.Widget;

namespace MauiMasters.Controls;

public partial class GroceryItemView : ContentView
{
    public static readonly BindableProperty GroceryItemProperty = BindableProperty.Create(nameof(GroceryItem), typeof(GroceryItem), typeof(GroceryItemView));

    public GroceryItem GroceryItem
    {
        get => (GroceryItem)GetValue(GroceryItemProperty);
        set
        {
            SetValue(GroceryItemProperty, value);
            BindingContext = value;
        } 
    }

    public GroceryItemView()
	{
		InitializeComponent();
	}
}