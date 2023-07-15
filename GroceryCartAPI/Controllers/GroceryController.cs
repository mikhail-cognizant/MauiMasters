using Common;
using GroceryCartAPI.Models;
using GroceryCartAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryCartAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GroceryController : Controller
{
    private readonly IGroceryCartService _service;

    public GroceryController(IGroceryCartService service)
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
    public void AddProducts([FromBody]IEnumerable<GroceryItem> products)
    {
        _service.AddGroceryItems(products);
    }

    [HttpDelete(Name = "Remove Products")]
    public void RemoveProducts([FromBody] IEnumerable<GroceryItem> products)
    {
        _service.RemoveGroceryItems(products);
    }

    [HttpPost("CalculateTotalPrice")]
    public CartTotals GetCartTotal([FromBody]IEnumerable<GroceryItem> groceryList)
    {
        return _service.CalculateTotalPrice(groceryList);
    }
}
