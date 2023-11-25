using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace eShop.IntegrationTests.cs
{
    public class ForceUpdateTests : IntegrationTest
    {
        public ForceUpdateTests(TestWebApplicationFactory factory) : base(factory)
        {
        }

        [Fact]
        public async Task WhenAppVersionIsOutdated_ReturnForceUpdateStatusCode()
        {
            
            _httpClient.DefaultRequestHeaders.Add("app-version", "1.0.0");  

           
            var response = await _httpClient.GetAsync("/api/endpoint"); 
 
            Assert.Equal(HttpStatusCode.UpgradeRequired, response.StatusCode);
        }

        [Fact]
        public async Task WhenAppVersionIsMalformed_ReturnBadRequestStatusCode()
        {
            
            _httpClient.DefaultRequestHeaders.Add("app-version", "invalid-version");
             
            var response = await _httpClient.GetAsync("/api/protected-endpoint");  
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

       
    }
}