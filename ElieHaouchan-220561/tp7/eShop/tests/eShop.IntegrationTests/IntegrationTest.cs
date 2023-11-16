using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MongoDbGenericRepository;

namespace eShop.IntegrationTests
{
    public abstract class IntegrationTest : IClassFixture<TestWebApplicationFactory>
    {
        private readonly TestWebApplicationFactory _factory;
        protected HttpClient _httpClient;
        public IntegrationTest(TestWebApplicationFactory factory)
        {
            _factory = factory;
            _httpClient = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    services.AddScoped<IMongoDbContext, MongoDbContext>(x =>
                    {
                        var mongoDbFixture = new MongoDbFixture();
                        return mongoDbFixture.MongoDbContext;
                    });
                    // You can add any additional services for testing here
                    // For example, configure in-memory databases, mock services, etc.
                });
            }).CreateClient();
        }
    }
    public class TestWebApplicationFactory : WebApplicationFactory<Program>
    {
    }
}
