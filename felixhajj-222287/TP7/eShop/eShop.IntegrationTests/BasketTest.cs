using eShop.Core.Entities;
using eShop.IntegrationTests;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

public class BasketTest : IntegrationTest
{
    public BasketTest(TestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task AddItemToBasket_ShouldSucceed()
    {
        var newBasket = new Basket("buyer123", new List<BasketItem>
        {
            new BasketItem(catalogItemId: 1, quantity: 2, unitPrice: 19.99m),
            new BasketItem(catalogItemId: 2, quantity: 1, unitPrice: 29.99m),
        });

        var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", newBasket);
        createResponse.EnsureSuccessStatusCode();

        var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();
        Assert.NotNull(createdBasket);

        var newItem = new BasketItem(catalogItemId: 3, quantity: 3, unitPrice: 39.99m);
        var addItemResponse = await _httpClient.PutAsJsonAsync($"/api/basket/{createdBasket.Id}", newItem);
        addItemResponse.EnsureSuccessStatusCode();

        var getResponse = await _httpClient.GetAsync($"/api/basket/{createdBasket.Id}");
        getResponse.EnsureSuccessStatusCode();

        var retrievedBasket = await getResponse.Content.ReadFromJsonAsync<Basket>();
        Assert.NotNull(retrievedBasket);

    }

    [Fact]
    public async Task DeleteBasket_ShouldSucceed()
    {
        var newBasket = new Basket("buyer123", new List<BasketItem>());
        var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", newBasket);
        createResponse.EnsureSuccessStatusCode();

        var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();
        Assert.NotNull(createdBasket);

        var deleteResponse = await _httpClient.DeleteAsync($"/api/basket/{createdBasket.Id}");
        deleteResponse.EnsureSuccessStatusCode();

        var getResponse = await _httpClient.GetAsync($"/api/basket/{createdBasket.Id}");

        Assert.Equal(System.Net.HttpStatusCode.NotFound, getResponse.StatusCode);
    }
}
