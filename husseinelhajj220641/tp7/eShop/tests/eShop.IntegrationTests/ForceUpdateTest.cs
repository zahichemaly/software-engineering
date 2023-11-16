using System;
using eShop.Core.Models;
using System.Net;
using System.Net.Http.Json;

namespace eShop.IntegrationTests
{
    public class ForceUpdateTest : IntegrationTest
    {
        public ForceUpdateTest(TestWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Theory]
        [InlineData("2.0.0")]
        [InlineData("3.1.0")]
        public async Task CheckForUpdate_WithCompatibleVersion_ShouldNotRequireUpgrade(string version)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            request.Headers.Add("app-version", version);

            var response = await _httpClient.SendAsync(request);

            Assert.NotEqual(HttpStatusCode.UpgradeRequired, response.StatusCode);
        }

        [Theory]
        [InlineData("1.0.0")]
        [InlineData("0.9.0")]
        public async Task CheckForUpdate_WithOutdatedVersion_ShouldDemandUpgrade(string version)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            request.Headers.Add("app-version", version);

            var response = await _httpClient.SendAsync(request);

            Assert.Equal(HttpStatusCode.UpgradeRequired, response.StatusCode);
        }

        [Theory]
        [InlineData("1.0")]
        [InlineData("abc")]
        public async Task CheckForUpdate_WithMalformedVersion_ShouldRejectRequest(string version)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            request.Headers.Add("app-version", version);

            var response = await _httpClient.SendAsync(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
