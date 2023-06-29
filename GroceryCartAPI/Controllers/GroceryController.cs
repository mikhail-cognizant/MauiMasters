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

    [HttpGet(Name = "GetProductById")]
    public GroceryItem GetProductById(int productId)
    {
        return _service.GetProductById(productId);
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

    //[HttpPost("AddProducts")]
    //public IEnumerable<GroceryItem> AddProducts([FromBody] IEnumerable<int> productIds)
    //{
    //    return _service.GetProductsById(productIds);
    //}
}
