using eShop.Core.Entities;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace eShop.IntegrationTests
{
    public class Basket_Test : IntegrationTest
    {
        private TestWebApplicationFactory _factory;
        public Basket_Test(TestWebApplicationFactory factory) : base(factory)
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
            var response = await _httpClient.GetAsync("/api/basket/nonexistent");
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task CreateBasket_And_GetBasketById_Should_Return_Same_Entity()
        {
            var httpClient = _factory.CreateClient();
            var buyerIdValue = "buyer1";
            var initialBasket = new Basket(buyerIdValue);
            initialBasket.AddItem(1, 10.0m, 1);

            var createResponse = await httpClient.PostAsJsonAsync("/api/Basket", initialBasket);
            createResponse.EnsureSuccessStatusCode();
            var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();

            var getResponse = await httpClient.GetAsync($"/api/Basket/{createdBasket.Id}");
            getResponse.EnsureSuccessStatusCode();
            var retrievedBasket = await getResponse.Content.ReadFromJsonAsync<Basket>();

            Assert.NotNull(retrievedBasket);
            Assert.Equal(createdBasket.Id, retrievedBasket.Id);
            Assert.Equal(initialBasket.BuyerId, retrievedBasket.BuyerId);

            Assert.Equal(initialBasket.Items.Count, retrievedBasket.Items.Count);

            var ex = Record.Exception(() =>
            {
                Assert.NotNull(retrievedBasket);
                Assert.Equal(createdBasket.Id, retrievedBasket.Id);
                var expectedItem = initialBasket.Items[0];
                var actualItem = retrievedBasket.Items[0];

                Assert.NotNull(actualItem);
                Assert.Equal(expectedItem.CatalogItemId, actualItem.CatalogItemId);
                Assert.Equal(expectedItem.UnitPrice, actualItem.UnitPrice);
                Assert.Equal(expectedItem.Quantity, actualItem.Quantity);
            });

            Assert.Null(ex);
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
        public async Task DeleteBasket_ShouldReturnNoContentAndDeleteBasket()
        {
            // Arrange
            var httpClient = _factory.CreateClient();
            var buyerIdValue = "buyer2";
            var basket = new Basket(buyerIdValue);
            var createResponse = await httpClient.PostAsJsonAsync("/api/Basket", basket);
            createResponse.EnsureSuccessStatusCode();
            var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();

            // Act
            var deleteResponse = await httpClient.DeleteAsync($"/api/Basket/{createdBasket.Id}");

            // Assert
            deleteResponse.EnsureSuccessStatusCode();
            var getResponse = await httpClient.GetAsync($"/api/Basket/{createdBasket.Id}");
            Assert.Equal(System.Net.HttpStatusCode.NotFound, getResponse.StatusCode);
        }
    }
}
