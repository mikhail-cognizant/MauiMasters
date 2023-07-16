using GroceryCartAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GroceryCartAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryCartController : Controller
    {
        private static List<GroceryItem>? groceryItems;

        public GroceryCartController()
        {
            InitializeList();
        }

        private void InitializeList()
        {
            //if (groceryItems == null) 
            //{
            //    groceryItems = new List<GroceryItem>()
            //    {
            //        new GroceryItem()
            //        {
            //            ItemName = "Banana",
            //            Price = 15
            //        },
            //        new GroceryItem()
            //        {
            //            ItemName = "Pear",
            //            Price = 50
            //        },
            //        new GroceryItem()
            //        {
            //            ItemName = "Apple",
            //            Price = 35
            //        }
            //    };
            //}
        }

        //[HttpGet(Name = "GetAvailableProducts")]
        //public IEnumerable<GroceryItem> Get()
        //{
        //    return groceryItems ?? new List<GroceryItem>();
        //}

        [HttpGet(Name = "GetProductByName")]
        public GroceryItem Get(string itemName)
        {
            if (groceryItems == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            var existingItem = groceryItems.FirstOrDefault(x => x.Name == itemName);

            if (existingItem != null) 
            {
                return existingItem;
            }
            else
            {
                throw new KeyNotFoundException("Product not found");
            }
        }

        [HttpPost(Name = "AddProduct")]
        public void Post(GroceryItem groceryItem) 
        {
            if (groceryItems == null)
            {
                groceryItems = new List<GroceryItem>();
            }

            if (groceryItems.Any(x => x?.Name?.ToUpper() == groceryItem?.Name?.ToUpper()))
            {
                throw new BadHttpRequestException("Item already exists");
            }

            groceryItems.Add(groceryItem);
        }

        [HttpPut(Name = "UpdateProduct")]
        public void Put(GroceryItem groceryItem)
        {
            if (groceryItems == null)
            {
                throw new Exception("no available products");
            }

            var existingItem = groceryItems.FirstOrDefault(x => x?.Name?.ToUpper() == groceryItem?.Name?.ToUpper());

            if (existingItem != null)
            {
                existingItem.Name = groceryItem.Name;
                existingItem.Price = groceryItem.Price;
            }
        }

        [HttpPatch(Name = "UpdateProductPrice/{newItemPrice}")]
        public void Patch(string groceryItemName, decimal? newItemPrice = null)
        {
            if (groceryItems == null)
            {
                throw new Exception("No available products");
            }

            var existingItem = groceryItems.FirstOrDefault(x => x?.Name?.ToUpper() == groceryItemName?.ToUpper());

            if (existingItem != null)
            {
                existingItem.Price = newItemPrice == null ? existingItem.Price : newItemPrice.Value;
            }
        }

        [HttpDelete(Name = "DeleteItem")]
        public void Delete(string groceryItemName)
        {
            if (groceryItems == null)
            {
                throw new Exception("No available products");
            }

            var itemToRemove = groceryItems.SingleOrDefault(x => x?.Name?.ToUpper() == groceryItemName?.ToUpper());

            if (itemToRemove != null)
            {
                groceryItems.Remove(itemToRemove);
            }
        }
    }
}
