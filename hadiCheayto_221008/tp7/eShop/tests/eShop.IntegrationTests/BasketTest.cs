using eShop.Core.Entities;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

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
        public async Task GetNonExistentEndpoint_ShouldReturnNotFound()
        {
            var response = await _httpClient.GetAsync("/api/basket/nonexistent");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateAndGetBasketById_ShouldMatchCreatedBasket()
        {

            var createPayload = new { /* ... payload data ... */ };
            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", createPayload);
            createResponse.EnsureSuccessStatusCode();
            var createResult = await createResponse.Content.ReadFromJsonAsync<Basket>();


            var getResponse = await _httpClient.GetAsync($"/api/basket/{createResult.Id}");
            getResponse.EnsureSuccessStatusCode(); 
            var getResult = await getResponse.Content.ReadFromJsonAsync<Basket>();

            Assert.Multiple(() =>
            {
                Assert.NotNull(getResult);
                Assert.Equal(createResult.Id, getResult.Id);
            });
        }

        [Fact]
        public async Task AddItemToExistingBasket_ShouldAddItem()
        {
            var newBasket = new Basket("buyer123");
            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", newBasket);
            createResponse.EnsureSuccessStatusCode();
            var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();

            var basketItem = new BasketItem(catalogItemId: 3, unitPrice: 15.0m, quantity: 3);
            var updateResponse = await _httpClient.PutAsJsonAsync($"/api/basket/{createdBasket.Id}", basketItem);
            updateResponse.EnsureSuccessStatusCode();

            var getResponse = await _httpClient.GetAsync($"/api/basket/{createdBasket.Id}");
            getResponse.EnsureSuccessStatusCode();
            var updatedBasket = await getResponse.Content.ReadFromJsonAsync<Basket>();

            Assert.NotNull(updatedBasket);
            Assert.Contains(updatedBasket.Items, item => item.CatalogItemId == 3 && item.Quantity == 3 && item.UnitPrice == 15.0m);
        }


        [Fact]
        public async Task DeleteBasket_ShouldSuccessfullyRemoveBasket()
        {
            var newBasket = new Basket("buyer456");
            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", newBasket);
            createResponse.EnsureSuccessStatusCode();
            var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();

            var deleteResponse = await _httpClient.DeleteAsync($"/api/basket/{createdBasket.Id}");
            deleteResponse.EnsureSuccessStatusCode();

            var getResponse = await _httpClient.GetAsync($"/api/basket/{createdBasket.Id}");
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        }


    }
}
