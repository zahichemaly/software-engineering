using System;
using eShop.Infrastructure.Data;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDbGenericRepository;

namespace eShop.IntegrationTests
{
    public class MongoDbFixture : IDisposable
    {
        public MongoDbContext MongoDbContext { get; }
        public MongoSettings MongoSettings { get; set; }
        public MongoDbFixture()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            MongoSettings mongoSettings = new MongoSettings();
            config.GetSection(nameof(MongoSettings)).Bind(mongoSettings);
            this.MongoDbContext = new MongoDbContext(mongoSettings.MongoConnection, mongoSettings.MongoDatabaseName);
            this.MongoSettings = mongoSettings;
        }
        public void Dispose()
        {
            var client = new MongoClient(MongoSettings.MongoConnection);
            client.DropDatabase(MongoSettings.MongoDatabaseName);
        }
    }

}

