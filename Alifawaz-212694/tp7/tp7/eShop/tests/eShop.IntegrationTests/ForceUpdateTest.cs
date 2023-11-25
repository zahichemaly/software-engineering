using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eShop.IntegrationTests
{
    public class ForceUpdateMiddlewareIntegrationTests : IClassFixture<TestWebApplicationFactory>
    {
        private readonly TestWebApplicationFactory _factory;

        public ForceUpdateMiddlewareIntegrationTests(TestWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task ForceUpdateMiddleware_OutdatedVersion_ShouldReturnForceUpdate()
        {

            var client = _factory.CreateClient();
            client.DefaultRequestHeaders.Add("app-version", "2.1.1");
            var response = await client.GetAsync("/api/some-endpoint"); 
            Assert.Equal(HttpStatusCode.UpgradeRequired, response.StatusCode);

           
        }

        [Fact]
        public async Task ForceUpdateMiddleware_LatestVersion_ShouldReturnOk()
        {
            
            var client = _factory.CreateClient();
            
            client.DefaultRequestHeaders.Add("app-version", "2.1.1");

            var response = await client.GetAsync("/api/some-endpoint"); 

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            
        }

        [Fact]
        public async Task ForceUpdateMiddleware_NoVersionHeader_ShouldReturnOk()
        {
            
            var client = _factory.CreateClient();

            
            var response = await client.GetAsync("/api/some-endpoint"); 

            
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

           
        }
    }
}

