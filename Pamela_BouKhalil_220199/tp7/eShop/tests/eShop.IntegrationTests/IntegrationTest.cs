using Microsoft.AspNetCore.Mvc.Testing;
using MongoDbGenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace eShop.IntegrationTests
{
    public abstract class IntegrationTest: IClassFixture<TestWebApplicationFactory>
    {
        private TestWebApplicationFactory _factory;
        protected HttpClient _httpClient;
        public IntegrationTest(TestWebApplicationFactory factory)
        {
            _factory = factory;
            _httpClient = _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureServices(services =>
                {
                    // You can add any additional services for testing here
                    // For example, configure in-memory databases, mock services, etc.
                    services.AddSingleton<IMongoDbContext, MongoDbContext>(x =>
                    {
                        var mongoDbFixture = new MongoDbFixture();
                        return mongoDbFixture.MongoDbContext;
                    });
                });
            }).CreateClient();
        }
    }
    public class TestWebApplicationFactory : WebApplicationFactory<Program>
    {
    }
}
    


