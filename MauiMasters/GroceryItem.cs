using Common;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiMasters;

public partial class GroceryItem : ObservableObject
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public decimal Price { get; set; }
    [ObservableProperty]
    private int quantity;
    private bool isAddedToCart;
    public bool IsAddedToCart
    {
        get => isAddedToCart;
        set
        { 
            SetProperty(ref isAddedToCart, value);
            ActionText = isAddedToCart ? "Update Quantity" : "Add To Cart";
        }
    }

    [ObservableProperty]
    private string actionText = "Add To Cart";

    public GroceryItemDto ToDto()
    {
        return new GroceryItemDto
        {
            Id = Id,
            Name = Name,
            Description = Description,
            ImageUrl = ImageUrl,
            Price = Price,
            Quantity = Quantity
        };
    }

    public static GroceryItem FromDto(GroceryItemDto dto)
    {
        return new GroceryItem
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Price = dto.Price,
            Quantity = dto.Quantity
        };
    }
}
