using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

public class BasketTest : IntegrationTest
{
    public BasketTest(TestWebApplicationFactory factory) : base(factory)
    {
    }

    [Fact]
    public async Task CreateAndRetrieveBasket_ShouldSucceed()
    {
        var newBasket = new Basket
        {};

        var createResponse = await _httpClient.PostAsJsonAsync("/api/basket", newBasket);
        createResponse.EnsureSuccessStatusCode();

        var createdBasket = await createResponse.Content.ReadFromJsonAsync<Basket>();
        Assert.NotNull(createdBasket);


        var getResponse = await _httpClient.GetAsync($"/api/basket/{createdBasket.Id}");
        getResponse.EnsureSuccessStatusCode();


        var retrievedBasket = await getResponse.Content.ReadFromJsonAsync<Basket>();
        Assert.NotNull(retrievedBasket);

        Assert.Multiple(() =>
        {
            Assert.NotNull(retrievedBasket);

            Assert.Equal(createdBasket.Id, retrievedBasket.Id);
        });

    }
}
