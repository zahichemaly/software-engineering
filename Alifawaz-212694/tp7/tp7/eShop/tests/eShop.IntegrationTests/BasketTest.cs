using eShop.Core.Entities;
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

        private readonly TestWebApplicationFactory _factory;
        public BasketTest(TestWebApplicationFactory factory) : base(factory)
        {
            _factory = factory;
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
        public async Task NonExistentEndpoint_ShouldReturnNotFoundStatusCode()
        {

            var response = await _httpClient.GetAsync("/api/nonexistent");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateBasketAndGetById_ShouldSucceed()
        {
            // Arrange
            var client = _factory.CreateClient();
            var newBasket = new Basket("user123");

            // Act
            var postResponse = await client.PostAsJsonAsync("/api/basket", newBasket);
            postResponse.EnsureSuccessStatusCode();
            var createdBasket = await postResponse.Content.ReadFromJsonAsync<Basket>();

            var getResponse = await client.GetAsync($"/api/basket/{createdBasket.Id}");
            getResponse.EnsureSuccessStatusCode();
            var retrievedBasket = await getResponse.Content.ReadFromJsonAsync<Basket>();

            // Assert
            Assert.NotNull(createdBasket);
            Assert.NotNull(retrievedBasket);
            Assert.Equal(createdBasket.Id, retrievedBasket.Id);
        }

        [Fact]
        public async Task AddItemToBasket_ShouldSucceed()
        {
            
            var client = _factory.CreateClient();
            var newBasket = new Basket("user123");

            var postResponse = await client.PostAsJsonAsync("/api/basket", newBasket);
            postResponse.EnsureSuccessStatusCode();
            var createdBasket = await postResponse.Content.ReadFromJsonAsync<Basket>();

            
            var basketItem = new BasketItem(1, 2, 3); 
            var putResponse = await client.PutAsJsonAsync($"/api/basket/{createdBasket.Id}", basketItem);
            putResponse.EnsureSuccessStatusCode();
            var updatedBasket = await putResponse.Content.ReadFromJsonAsync<Basket>();

            
            Assert.NotNull(updatedBasket);
            Assert.Equal(createdBasket.Id, updatedBasket.Id);
            Assert.Equal(1, updatedBasket.Items.Count); 
        }
        [Fact]
        public async Task DeleteBasket_ShouldSucceed()
        {
           
            var client = _factory.CreateClient();
            var newBasket = new Basket("user123");

            var postResponse = await client.PostAsJsonAsync("/api/basket", newBasket);
            postResponse.EnsureSuccessStatusCode();
            var createdBasket = await postResponse.Content.ReadFromJsonAsync<Basket>();

            var deleteResponse = await client.DeleteAsync($"/api/basket/{createdBasket.Id}");
            deleteResponse.EnsureSuccessStatusCode();

            var getResponse = await client.GetAsync($"/api/basket/{createdBasket.Id}");

            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        }
    }
}





