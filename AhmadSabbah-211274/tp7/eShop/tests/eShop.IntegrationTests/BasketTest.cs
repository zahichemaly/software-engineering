using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using eShop.Core.Entities;
using eShop.IntegrationTests;
using Intuit.Ipp.Core.Configuration;
using RestSharp;
using System;
//using System.Net.Http.Json;
using ZstdSharp.Unsafe;
using Microsoft.AspNetCore.Mvc;


public class BasketTest : IntegrationTest
{
    private static readonly string BaseUrl = "http://your-api-base-url";
    

    // Other test methods...
    public BasketTest(TestWebApplicationFactory factory) : base(factory)
    {
    }
    [Fact]
    public async Task GetBasket_ShouldReturnSuccessStatusCode()
    {
        var response = await _httpClient.GetAsync("/api/basket");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadFromJsonAsync<IEnumerable<basket>>();
        Assert.NotNull(result);
    }


  /* public async Task TestCreateAndRetrieveBasket()
   {
        // Step 1: Create a basket
        var basket = new Basket
        {
            // Add properties of the basket
            // For example:
            // Id = 1,
            // Items = new List<Item>(),
            // ...
        };

        // Step 2: Use PostAsJsonAsync() to insert the basket into the DB
        var postResponse = await PostBasketAsync(basket);

        // Step 3: Parse the response using ReadFromJsonAsync()
        var createdBasket = await postResponse.Content.ReadFromJsonAsync<basket>();

        // Step 4: Call get basket by ID using GetAsync()
        var getResponse = await GetBasketByIdAsync(createdBasket.Id);

        // Step 5: Parse the response
        var retrievedBasket = await getResponse.Content.ReadFromJsonAsync<basket>();

        // Now, you can assert or perform further actions based on the created and retrieved baskets
   }*/

    private async Task<HttpResponseMessage> PostBasketAsync(basket basket)
    {
        using (var client = new HttpClient())
        {
            var postResponse = await client.PostAsJsonAsync($"{BaseUrl}/api/baskets", basket);
            return postResponse;
        }
    }


    private async Task<HttpResponseMessage> GetBasketByIdAsync(int basketId)
    {
        using (var client = new HttpClient())
        {
            var getResponse = await client.GetAsync($"{BaseUrl}/api/baskets/{basketId}");
            return getResponse;
        }
    }
    
        
        }
        



