﻿using System;

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
