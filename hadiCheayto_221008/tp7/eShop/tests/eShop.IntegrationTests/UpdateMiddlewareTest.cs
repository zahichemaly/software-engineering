using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eShop.IntegrationTests
{
    public class UpdateMiddlewareTest : IntegrationTest
    {
        public UpdateMiddlewareTest(TestWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Theory]
        [InlineData("2.0.0")]
        [InlineData("3.1.0")]
        public async Task ForceUpdate_WithValidVersion_ShouldContinue(string version)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            request.Headers.Add("app-version", version);

            var response = await _httpClient.SendAsync(request);

            Assert.NotEqual(HttpStatusCode.UpgradeRequired, response.StatusCode);
        }

        [Theory]
        [InlineData("1.0.0")]
        [InlineData("0.9.0")]
        public async Task ForceUpdate_WithUnsupportedVersion_ShouldReturnUpgradeRequired(string version)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            request.Headers.Add("app-version", version);

            var response = await _httpClient.SendAsync(request);

            Assert.Equal(HttpStatusCode.UpgradeRequired, response.StatusCode);
        }

        [Theory]
        [InlineData("1.0")]
        [InlineData("abc")]
        public async Task ForceUpdate_WithInvalidVersionFormat_ShouldReturnBadRequest(string version)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "/");
            request.Headers.Add("app-version", version);

            var response = await _httpClient.SendAsync(request);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }


    }
    
}
