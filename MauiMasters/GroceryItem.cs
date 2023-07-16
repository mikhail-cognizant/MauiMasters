using Common;
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


    public static GroceryItem FromDto(GroceryItemDto dto)
    {
        return new GroceryItem
        {
            Name = dto.Name,
            Description = dto.Description,
            ImageUrl = dto.ImageUrl,
            Price = dto.Price
        };
    }
}
