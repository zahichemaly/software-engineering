using eShop.Core.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json; // Ensure this namespace is imported
using System.Threading.Tasks;
using Xunit;

namespace eShop.IntegrationTests
{
    public class ForceUpdateMiddlewareTests : IClassFixture<TestWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;

        public ForceUpdateMiddlewareTests(TestWebApplicationFactory factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task WhenAppVersionIsOutdated_ShouldReturnForceUpdateStatusCode()
        {
            // Arrange: Set an outdated version in the header
            _httpClient.DefaultRequestHeaders.Add("app-version", "1.0.0"); // Assuming this version is outdated

            // Act
            var response = await _httpClient.GetAsync("/api/endpoint"); // Replace with your API endpoint triggering force update

            // Assert
            Assert.Equal(HttpStatusCode.UpgradeRequired, response.StatusCode);
            // Add more assertions as necessary based on the expected behavior of the force update response
        }

        [Fact]
        public async Task WhenAppVersionIsMalformed_ShouldReturnBadRequestStatusCode()
        {
            // Arrange: Set a malformed version in the header
            _httpClient.DefaultRequestHeaders.Add("app-version", "invalid-version");

            // Act: Send a request to the endpoint protected by the ForceUpdateMiddleware
            var response = await _httpClient.GetAsync("/api/protected-endpoint"); // Replace with your protected endpoint

            // Assert: Check if the response status code is BadRequest
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        
    }
}

