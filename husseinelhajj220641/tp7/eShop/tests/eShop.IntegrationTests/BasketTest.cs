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
        public async Task RequestToInvalidEndpoint_ShouldYieldNotFound()
        {
            var response = await _httpClient.GetAsync("/api/basket/oygtfrgbhnj");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }


        [Fact]
        public async Task BasketCreationAndRetrieval_ShouldBeConsistent()
        {
            var basket = new Basket("buyer123");
            basket.AddItem(catalogItemId: 1, unitPrice: 10.0m, quantity: 2);

            var createResp = await _httpClient.PostAsJsonAsync("/api/basket", basket);
            createResp.EnsureSuccessStatusCode();

            var created = await createResp.Content.ReadFromJsonAsync<Basket>();
            Assert.NotNull(created);
            Assert.Equal("buyer123", created.BuyerId);
            Assert.Single(created.Items);
            Assert.Equal(2, created.TotalItems);

            var getResp = await _httpClient.GetAsync($"/api/basket/{created.Id}");
            getResp.EnsureSuccessStatusCode();
            var retrieved = await getResp.Content.ReadFromJsonAsync<Basket>();

            Assert.NotNull(retrieved);
            Assert.Equal(created.Id, retrieved.Id);
        }


        [Fact]
        public async Task AddingItemToBasket_ShouldReflectInBasketContents()
        {
            var basket = new Basket("buyer123");
            var creationResponse = await _httpClient.PostAsJsonAsync("/api/basket", basket);
            creationResponse.EnsureSuccessStatusCode();
            var created = await creationResponse.Content.ReadFromJsonAsync<Basket>();

            var itemToAdd = new BasketItem(catalogItemId: 3, unitPrice: 15.0m, quantity: 3);
            var updateResp = await _httpClient.PutAsJsonAsync($"/api/basket/{created.Id}", itemToAdd);
            updateResp.EnsureSuccessStatusCode();

            var getResp = await _httpClient.GetAsync($"/api/basket/{created.Id}");
            getResp.EnsureSuccessStatusCode();
            var updated = await getResp.Content.ReadFromJsonAsync<Basket>();

            Assert.NotNull(updated);
            Assert.Contains(updated.Items, i => i.CatalogItemId == 3 && i.Quantity == 3 && i.UnitPrice == 15.0m);
        }


        [Fact]
        public async Task DeletingBasket_ShouldLeadToItsAbsence()
        {
            var basket = new Basket("buyer456");
            var creationResp = await _httpClient.PostAsJsonAsync("/api/basket", basket);
            creationResp.EnsureSuccessStatusCode();
            var created = await creationResp.Content.ReadFromJsonAsync<Basket>();

            var deleteResp = await _httpClient.DeleteAsync($"/api/basket/{created.Id}");
            deleteResp.EnsureSuccessStatusCode();

            var getResp = await _httpClient.GetAsync($"/api/basket/{created.Id}");
            Assert.Equal(HttpStatusCode.NotFound, getResp.StatusCode);
        }




    }

}
