using Common;

namespace GroceryCartAPI.Models;

public class GroceryItem
{
    public int Id { get; set; }
    public string? ItemName { get; set; }
    public int? Price { get; set; }

    public GroceryItemDto ToDto()
    {
        return new GroceryItemDto
        {
            Id = Id,
            ItemName = ItemName,
            Price = Price
        };
    }
}
