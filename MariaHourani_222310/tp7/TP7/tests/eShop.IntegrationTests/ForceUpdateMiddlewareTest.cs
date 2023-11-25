using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using eShop.Core.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace eShop.IntegrationTests
{
    public class ForceUpdateMiddlewareTest : IntegrationTest
    {
        private TestWebApplicationFactory _factory;
        public ForceUpdateMiddlewareTest(TestWebApplicationFactory factory) : base(factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ForceUpdateMiddleware_ShouldReturnUpgradeRequiredForOldVersion()
        {
            // Arrange
            var httpClient = _factory.CreateClient();
            var outdatedVersion = "1.0.0"; // Replace with an outdated version
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/some-endpoint");
            request.Headers.Add("app-version", outdatedVersion);

            // Act
            var response = await httpClient.SendAsync(request);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.UpgradeRequired, response.StatusCode);
            var errorModel = await response.Content.ReadFromJsonAsync<ErrorModel>();
            Assert.NotNull(errorModel);
            Assert.Equal("version_not_supported", errorModel.Code);
            Assert.Equal("The current version of the app is no longer supported. Please update it and try again", errorModel.Description);
        }

        [Fact]
        public async Task ForceUpdateMiddleware_ShouldContinueForRecentVersion()
        {
            // Arrange
            var httpClient = _factory.CreateClient();
            var recentVersion = "2.0.0";  // Assuming this is a recent version
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/some-endpoint");
            request.Headers.Add("app-version", recentVersion);

            // Act
            var response = await httpClient.SendAsync(request);

            // Assert
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async Task ForceUpdateMiddleware_ShouldReturnBadRequestForMalformattedVersion()
        {
            // Arrange
            var httpClient = _factory.CreateClient();
            var malformattedVersion = "invalid-version"; 
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/some-endpoint");
            request.Headers.Add("app-version", malformattedVersion);

            // Act
            var response = await httpClient.SendAsync(request);

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
            var errorModel = await response.Content.ReadFromJsonAsync<ErrorModel>();
            Assert.NotNull(errorModel);
            Assert.Equal("bad_version", errorModel.Code);
            Assert.Contains("Version malformatted", errorModel.Description);
        }
    }
}
