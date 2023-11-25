using System;

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

}
