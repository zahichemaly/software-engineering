using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using eShop.Core.Entities;
using eShop.IntegrationTests;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class BasketControllerIntegrationTest : IClassFixture<TestWebApplicationFactory>
{
    private readonly HttpClient _httpClient;

    public BasketControllerIntegrationTest(TestWebApplicationFactory factory)
    {
        _httpClient = factory.CreateClient();
    }

    public int GetQuantity()
    {
        return Quantity;
    }

    [Fact]
    public async Task AddAndDeleteItemFromBasket_ShouldSucceed(int quantity)
    {
        // Step 1: Create a basket
        var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", new Basket());
        createResponse.EnsureSuccessStatusCode();
        var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();

        // Step 2: Add an item to the basket
        var addItemResponse = await _httpClient.PutAsJsonAsync($"/api/basket/{createdBasket.Id}", new BasketItem
        {
            CatalogItemId = 1, // Replace with an actual catalog item ID
            UnitPrice = 19.99, // Replace with an actual unit price
            quantity = 1
        });
        addItemResponse.EnsureSuccessStatusCode();

        // Step 3: Verify that the item was added to the basket
        var getBasketResponse = await _httpClient.GetAsync($"/api/basket/{createdBasket.Id}");
        getBasketResponse.EnsureSuccessStatusCode();
        var retrievedBasket = await getBasketResponse.Content.ReadFromJsonAsync<Basket>();
        Assert.NotNull(retrievedBasket);
        Assert.NotEmpty(retrievedBasket.Items);

        // Step 4: Delete the basket
        var deleteResponse = await _httpClient.DeleteAsync($"/api/basket/{createdBasket.Id}");
        deleteResponse.EnsureSuccessStatusCode();

        // Step 5: Verify that the basket was deleted
        var getDeletedBasketResponse = await _httpClient.GetAsync($"/api/basket/{createdBasket.Id}");
        Assert.Equal(System.Net.HttpStatusCode.NotFound, getDeletedBasketResponse.StatusCode);
    }
}
