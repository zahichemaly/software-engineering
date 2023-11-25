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
            // Arrange: Define a non-existent endpoint
            var nonExistentEndpoint = "/api/basket/nonexistent";

            // Act: Make a request to the non-existent endpoint
            var response = await _httpClient.GetAsync(nonExistentEndpoint);


            // Assert: Verify that the response has a status code of NotFound (404)
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateAndRetrieveBasket_ShouldSucceed()
        {
            // Arrange
            var buyerId = "testBuyerId"; // Replace with an appropriate buyer ID for your test
            var catalogItemId = 1; // Replace with an appropriate catalog item ID for your test
            var unitPrice = 10.99m; // Replace with an appropriate unit price for your test
            var quantity = 3; // Replace with an appropriate quantity for your test

            // Step 1: Create a basket
            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", new
            {
                BuyerId = buyerId
                // You may need to include other properties if required by your API
            });

            // Assert
            createResponse.EnsureSuccessStatusCode();

            var createResult = await createResponse.Content.ReadFromJsonAsync<Basket>();

            Assert.NotNull(createResult);
            Assert.Equal(buyerId, createResult.BuyerId);
            Assert.Empty(createResult.Items);

            var addItemResponse = await _httpClient.PutAsJsonAsync($"/api/basket/{createResult.Id}", new
            {
                CatalogItemId = catalogItemId,
                UnitPrice = unitPrice,
                Quantity = quantity
            });

            addItemResponse.EnsureSuccessStatusCode();

            var getResponse = await _httpClient.GetAsync($"/api/basket/{createResult.Id}");

            var getResult = await getResponse.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(getResult);
            Assert.Equal(createResult.Id, getResult.Id);
            Assert.Multiple(() =>
            {
                Assert.NotNull(getResult);
                Assert.Equal(createResult.Id, getResult.Id);
                Assert.Equal(buyerId, getResult.BuyerId);

                // Add more assertions as needed based on your specific implementation
            });
        }

        [Fact]
        public async Task CreateUpdateAndRetrieveBasket_ShouldSucceed()
        {
            // Arrange
            var buyerId = "testBuyerId"; // Replace with an appropriate buyer ID for your test
            var catalogItemId = 1; // Replace with an appropriate catalog item ID for your test
            var unitPrice = 10.99m; // Replace with an appropriate unit price for your test
            var quantity = 3; // Replace with an appropriate quantity for your test

            // Step 1: Create a basket
            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", new
            {
                BuyerId = buyerId
                // You may need to include other properties if required by your API
            });

            // Assert
            createResponse.EnsureSuccessStatusCode();

            var createResult = await createResponse.Content.ReadFromJsonAsync<Basket>();

            Assert.NotNull(createResult);
            Assert.Equal(buyerId, createResult.BuyerId);
            Assert.Empty(createResult.Items);

            // Step 2: Update the basket by adding an item
            var addItemResponse = await _httpClient.PutAsJsonAsync($"/api/basket/{createResult.Id}", new
            {
                CatalogItemId = catalogItemId,
                UnitPrice = unitPrice,
                Quantity = quantity
            });

            addItemResponse.EnsureSuccessStatusCode();

            // Step 3: Retrieve the updated basket
            var getResponse = await _httpClient.GetAsync($"/api/basket/{createResult.Id}");

            var getResult = await getResponse.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(getResult);

            // Assert: Verify the updated basket properties
            Assert.Equal(createResult.Id, getResult.Id);
            Assert.Equal(buyerId, getResult.BuyerId);

            // Assert: Verify the added item in the basket
            Assert.Single(getResult.Items); // Assuming only one item is added
            var addedItem = getResult.Items.First();
            Assert.Equal(catalogItemId, addedItem.CatalogItemId);
            Assert.Equal(unitPrice, addedItem.UnitPrice);
            Assert.Equal(quantity, addedItem.Quantity);

            // Add more assertions as needed based on your specific implementation
        }

        [Fact]
        public async Task CreateDeleteBasket_ShouldSucceed()
        {
            // Arrange
            var buyerId = "testBuyerId"; // Replace with an appropriate buyer ID for your test
            var catalogItemId = 1; // Replace with an appropriate catalog item ID for your test
            var unitPrice = 10.99m; // Replace with an appropriate unit price for your test
            var quantity = 3; // Replace with an appropriate quantity for your test

            // Step 1: Create a basket
            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", new
            {
                BuyerId = buyerId
                // You may need to include other properties if required by your API
            });

            // Assert
            createResponse.EnsureSuccessStatusCode();

            var createResult = await createResponse.Content.ReadFromJsonAsync<Basket>();

            Assert.NotNull(createResult);
            Assert.Equal(buyerId, createResult.BuyerId);
            Assert.Empty(createResult.Items);

            // Step 2: Update the basket by adding an item
            var addItemResponse = await _httpClient.PutAsJsonAsync($"/api/basket/{createResult.Id}", new
            {
                CatalogItemId = catalogItemId,
                UnitPrice = unitPrice,
                Quantity = quantity
            });

            addItemResponse.EnsureSuccessStatusCode();

            // Step 3: Delete the basket
            var deleteResponse = await _httpClient.DeleteAsync($"/api/basket/{createResult.Id}");

            // Assert: Verify that the basket is deleted successfully
            deleteResponse.EnsureSuccessStatusCode();

            // Step 4: Try to retrieve the deleted basket
            var getResponse = await _httpClient.GetAsync($"/api/basket/{createResult.Id}");

            // Assert: Verify that the retrieval returns NotFound (HTTP 404)
            Assert.Equal(HttpStatusCode.NotFound, getResponse.StatusCode);
        }


    }
}
    
