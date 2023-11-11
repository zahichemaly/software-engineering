/*using _NewsBoard.Data.Mongo.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Repositories;

namespace NewsBoard.API
{


    public class Startup
    {

        private readonly WebApplicationBuilder builder;

        public Startup(WebApplicationBuilder builder)
        {
            this.builder = builder;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<INewsRepository, NewsRepository>();
            services.AddSingleton(x => new MongoClient(builder.Configuration.GetConnectionString("MongoDbConnection")));
        }
        




    }
}

*/