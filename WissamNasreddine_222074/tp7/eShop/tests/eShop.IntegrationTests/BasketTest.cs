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
        private TestWebApplicationFactory _factory;
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
        public async Task NonExistingEndpoint_ShouldReturnNotFoundStatusCode()
        {

            var nonExistingEndpoint = "/api/Basket/NoItem";
            var response = await _httpClient.GetAsync(nonExistingEndpoint);
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateBasket_And_GetBasketById_Should_Return_Same_Entity()
        {
            // Arrange
            var client = _factory.CreateClient();
            var buyerId = "buyer123"; // Replace with a valid buyer ID
            var basket = new Basket(buyerId);
            basket.AddItem(1, 20.0m, 2); // Add a sample item

            // Act
            // Step 1: Create a basket
            var createResponse = await client.PostAsJsonAsync("/api/Basket", basket);
            createResponse.EnsureSuccessStatusCode();
            var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();

            // Step 2: Get basket by ID
            var getResponse = await client.GetAsync($"/api/Basket/{createdBasket.Id}");
            getResponse.EnsureSuccessStatusCode();
            var retrievedBasket = await getResponse.Content.ReadFromJsonAsync<Basket>();

            // Assert
            // Step 3: Perform assertions
            Assert.NotNull(retrievedBasket);
            Assert.Equal(createdBasket.Id, retrievedBasket.Id);
            Assert.Equal(basket.BuyerId, retrievedBasket.BuyerId);

            // Additional assertions for the BasketItem list
            Assert.Equal(basket.Items.Count, retrievedBasket.Items.Count);
            Assert.Multiple(() =>
            {
                Assert.NotNull(retrievedBasket); // Assertion (a)
                Assert.Equal(createdBasket.Id, retrievedBasket.Id); // Assertion (b)

                // Assertions for BasketItem
                var expectedItem = basket.Items[0]; // Assuming only one item for simplicity
                var actualItem = retrievedBasket.Items[0];

                Assert.NotNull(actualItem);
                Assert.Equal(expectedItem.CatalogItemId, actualItem.CatalogItemId);
                Assert.Equal(expectedItem.UnitPrice, actualItem.UnitPrice);
                Assert.Equal(expectedItem.Quantity, actualItem.Quantity);
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
        public async Task DeleteBasket_Should_Remove_Basket()
        {
            // Arrange
            var client = _factory.CreateClient();
            var buyerId = "buyer123"; // Replace with a valid buyer ID
            var basket = new Basket(buyerId);
            await client.PostAsJsonAsync("/api/Basket", basket); // Create a basket

            // Act
            // Delete the basket
            var deleteResponse = await client.DeleteAsync($"/api/Basket/{basket.Id}");
            deleteResponse.EnsureSuccessStatusCode();

            // Try to get the deleted basket
            var getDeletedResponse = await client.GetAsync($"/api/Basket/{basket.Id}");

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.NotFound, getDeletedResponse.StatusCode);
        }

    }

}
