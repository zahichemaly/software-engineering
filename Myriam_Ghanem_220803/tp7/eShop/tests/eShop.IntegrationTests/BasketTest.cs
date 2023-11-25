// BasketTest.cs
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using eShop.Application.Controllers;
using eShop.Core.Entities;
using Xunit;

namespace eShop.IntegrationTests
{
    public class BasketTest : IntegrationTest
    {
        public BasketTest(TestWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task GetBasket_ShouldReturnSuccessStatusCode()
        {
            var response = await _httpClient.GetAsync("/api/basket");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadFromJsonAsync<IEnumerable<Basket>>();
            Assert.NotNull(result);
        }

        [Fact]
        public async Task NonExistentEndpoint_ShouldReturnNotFound()
        {
            var response = await _httpClient.GetAsync("/api/basket/nonexistent");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateBasket_ShouldReturnSuccess()
        {
           
            var newBasket = new Basket("buyer123"); 
            newBasket.AddItem(catalogItemId: 1, unitPrice: 10.0m, quantity: 2); 

            // Send a POST request to create the basket
            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", newBasket);
            createResponse.EnsureSuccessStatusCode();


            var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(createdBasket);
            Assert.Equal("buyer123", createdBasket.BuyerId);
            Assert.Equal(1, createdBasket.Items.Count);
            Assert.Equal(2, createdBasket.TotalItems);

            var getResponse = await _httpClient.GetAsync($"/api/basket/{createdBasket.Id}");
            getResponse.EnsureSuccessStatusCode();
            var retrievedBasket = await getResponse.Content.ReadFromJsonAsync<Basket>();

            Assert.NotNull(retrievedBasket);
            Assert.Equal(createdBasket.Id, retrievedBasket.Id);

        }
 

        [Fact]
        public async Task AddItemToBasket_ShouldReturnSuccess()
        {
            // Create a basket
            var newBasket = new Basket("buyer123");
            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", newBasket);
            createResponse.EnsureSuccessStatusCode();
            var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(createdBasket);

            // Add an item to the basket
            var newItem = new BasketItem(catalogItemId: 1, quantity: 2, unitPrice: 10.0m);

            var addItemResponse = await _httpClient.PutAsJsonAsync($"/api/basket/{createdBasket.Id}", newItem);
            addItemResponse.EnsureSuccessStatusCode();

            // Fetch the updated basket
            var updatedBasketResponse = await _httpClient.GetAsync($"/api/basket/{createdBasket.Id}");
            updatedBasketResponse.EnsureSuccessStatusCode();
            var updatedBasket = await updatedBasketResponse.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(updatedBasket);

            // Perform assertions
            Assert.Equal(1, updatedBasket.Items.Count); 
            Assert.Equal(2, updatedBasket.TotalItems); 
                                                      
        }

        [Fact]
        public async Task DeleteBasket_ShouldReturnNoContent()
        {
            
            var newBasket = new Basket("buyer123");
            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", newBasket);
            createResponse.EnsureSuccessStatusCode();
            var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(createdBasket);

           
            var deleteResponse = await _httpClient.DeleteAsync($"/api/basket/{createdBasket.Id}");
            deleteResponse.EnsureSuccessStatusCode();

           
            var getDeletedResponse = await _httpClient.GetAsync($"/api/basket/{createdBasket.Id}");
            Assert.Equal(HttpStatusCode.NotFound, getDeletedResponse.StatusCode);
        }


    }
}
