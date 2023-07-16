using Common;
using MauiMasters.Constants;
using System.Text;
using System.Text.Json;

namespace MauiMasters.Services;

public class GroceryService : IGroceryService
{
    private HttpClient client;
    private JsonSerializerOptions serializerOptions;

    private string groceryRoute = DeviceInfo.Platform == DevicePlatform.Android
            ? $"{GroceryAPIConsts.GroceryAPIURLDroid}GroceryCart"
            : $"{GroceryAPIConsts.GroceryAPIURL}GroceryCart";

    public GroceryService()
    {
        client = new HttpClientService().GetPlatfromSpecificHttpClient();

        serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }

    public async Task<IEnumerable<GroceryItem>> GetGroceryItems()
    {
        var groceries = new List<GroceryItem>();

        Uri uri = new Uri(groceryRoute);

        HttpResponseMessage response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            var groceryDTOs = JsonSerializer.Deserialize<List<GroceryItemDto>>(content, serializerOptions);

            if (groceryDTOs?.Any() ?? false)
            {
                groceries = groceryDTOs.Select(x => GroceryItem.FromDto(x)).ToList();
            }
        }

        return groceries;
    }

    public async Task<bool> AddGroceryItem(GroceryItem item)
    {
        var itemsToBeAdded = new List<GroceryItemDto>
        { 
            item.ToDto()
        };

        Uri uri = new Uri(groceryRoute);

        string json = JsonSerializer.Serialize(itemsToBeAdded, serializerOptions);
        StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await client.PostAsync(uri, content);

        return response.IsSuccessStatusCode;
    }

    public async Task<CartTotals> GetCartTotal()
    {
        CartTotals total = new CartTotals();

        Uri uri = new Uri(groceryRoute + "/carttotal");

        HttpResponseMessage response = await client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            total = JsonSerializer.Deserialize<CartTotals>(content, serializerOptions);
        }

        return total;
    }

    public async Task<bool> ClearCart()
    {
        Uri uri = new Uri(groceryRoute + "/clearcart");

        HttpResponseMessage response = await client.DeleteAsync(uri);
        return response.IsSuccessStatusCode;
    }
}
