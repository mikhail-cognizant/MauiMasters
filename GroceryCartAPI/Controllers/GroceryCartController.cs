using Common;
using GroceryCartAPI.Models;
using GroceryCartAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace GroceryCartAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroceryCartController : Controller
{
    private readonly IGroceryCartService _service;

    public GroceryCartController(IGroceryCartService service)
    {
        _service = service;
    }

    [HttpGet(Name = "GetAllProducts")]
    public IEnumerable<GroceryItemDto> GetAllProducts()
    {
        return _service.GetAllProducts().Select(p => p.ToDto());
    }

    [HttpGet("{productId}")]
    public GroceryItemDto GetProductById(int productId)
    {
        return _service.GetProductById(productId).ToDto();
    }

    [HttpPost(Name = "Add Products")]
    public void AddProducts([FromBody]IEnumerable<GroceryItemDto> products)
    {
        _service.AddGroceryItems(products.Select(p => GroceryItem.FromDto(p)));
    }

    [HttpDelete(Name = "Remove Products")]
    public void RemoveProducts([FromBody] IEnumerable<GroceryItemDto> products)
    {
        _service.RemoveGroceryItems(products.Select(p => GroceryItem.FromDto(p)));
    }

    [HttpGet()]
    [Route("carttotal")]
    public CartTotals GetCartTotal()
    {
        return _service.CalculateTotalPrice();
    }
}
