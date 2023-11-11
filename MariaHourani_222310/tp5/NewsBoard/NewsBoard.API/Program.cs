using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using NewsBoard.Business.Handlers;
using NewsBoard.Business.Models;
using NewsBoard.Data;
using NewsBoard.Data.Mongo;
using MediatR;
using CacheManager.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Configure MongoDB connection
builder.Configuration.AddJsonFile("appsettings.json");
var connectionString = builder.Configuration.GetConnectionString("MongoDbConnection");
builder.Configuration.AddJsonFile("caching.json");
builder.Services.AddCacheManagerConfiguration(builder.Configuration)
 .AddCacheManager();
builder.Services.AddSingleton(x => new MongoClient(connectionString));

// Register repositories
builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddScoped<NewsRepository>();
builder.Services.AddScoped<INewsRepository>(sp =>
{
    var newsRepository = sp.GetRequiredService<NewsRepository>();
    var cacheManager = sp.GetRequiredService<ICacheManager<News>>();
    var cacheManagerForList = sp.GetRequiredService<ICacheManager<IEnumerable<News>>>();
    return new CacheNewsDecoratorRepository(newsRepository, cacheManager, cacheManagerForList);
});

// Register MediatR
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssemblyContaining(typeof(CreateNewsHandler)));


// Add Swagger for API documentation
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
