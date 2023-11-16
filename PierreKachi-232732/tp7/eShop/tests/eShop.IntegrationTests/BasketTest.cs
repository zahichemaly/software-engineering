﻿using eShop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task NonExistentEndpoint_ShouldReturnNotFoundStatusCode()
        {
            var response = await _httpClient.GetAsync("/api/basket/nonexistentendpoint");
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateAndRetrieveBasket_ShouldSucceed()
        {
            
            var buyerId = "testBuyerId"; 
            var catalogItemId = 1; 
            var unitPrice = 10.99m; 
            var quantity = 3; 

            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", new
            {
                BuyerId = buyerId
            });

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

            });
        }
        [Fact]
        public async Task AddItemToBasket_ShouldSucceed()
        {
            var buyerId = "testBuyerId"; 
            var catalogItemId = 1; 
            var unitPrice = 10.99m;
            var quantity = 3;

            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", new
            {
                BuyerId = buyerId
            });

            createResponse.EnsureSuccessStatusCode();

            var createResult = await createResponse.Content.ReadFromJsonAsync<Basket>();

            Assert.NotNull(createResult);

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
                Assert.Single(getResult.Items); 
                });
        }

        [Fact]
        public async Task DeleteBasket_ShouldSucceed()
        {
            var buyerId = "testBuyerId"; 
            var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", new
            {
                BuyerId = buyerId
            });

            createResponse.EnsureSuccessStatusCode();

            var createResult = await createResponse.Content.ReadFromJsonAsync<Basket>();

            Assert.NotNull(createResult);

            var deleteResponse = await _httpClient.DeleteAsync($"/api/basket/{createResult.Id}");

            deleteResponse.EnsureSuccessStatusCode();

            var getResponse = await _httpClient.GetAsync($"/api/basket/{createResult.Id}");

            Assert.Equal(System.Net.HttpStatusCode.NotFound, getResponse.StatusCode);
        }
    }
}
    
    
