using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiMasters;

public partial class GroceryItem : ObservableObject
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    [ObservableProperty]
    private int quantity;
}
