using Common;

namespace GroceryCartAPI.Models;

public class GroceryItem
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public decimal Price { get; set; }

    public GroceryItemDto ToDto()
    {
        return new GroceryItemDto
        {
            Id = Id,
            Name = Name,
            Description = Description,
            ImageUrl = ImageUrl,
            Price = Price
        };
    }
}
