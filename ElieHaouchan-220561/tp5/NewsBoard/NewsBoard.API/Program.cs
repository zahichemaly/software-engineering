using MongoDB.Driver;
using NewsBoard.Business.DTOs;
using NewsBoard.Business.Handlers;
using NewsBoard.Data.Entities;
using NewsBoard.Data.Mongo.Repositories;
using NewsBoard.Data.Repositories;

namespace NewsBoard.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton(x =>
            {
                var connectionString = builder.Configuration.GetConnectionString("MongoDbConnection");
                return new MongoClient(connectionString);
            });

            builder.Services.AddScoped<INewsRepository, NewsRepository>();
            builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssemblyContaining(typeof(CreateNewsHandler)));
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            builder.Configuration.AddJsonFile("caching.json");
            builder.Services.AddCacheManagerConfiguration(builder.Configuration)
             .AddCacheManager();

            var app = builder.Build();

                        
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}