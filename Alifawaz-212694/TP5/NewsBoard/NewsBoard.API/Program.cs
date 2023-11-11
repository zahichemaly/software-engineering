using NewsBoard.Data.Repositories;
using NewsBoard.Data.Mongo.Repository;
using NewsBoard.Buisiness.Handlers;
using NewsBoard.Buisiness.DTOs;
using NewsBoard.Data.Entities;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MongoDB.Driver;
using NewsBoard.API;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssemblyContaining(typeof(CreateNewsHandler)));
builder.Services.AddMediatR(cfg =>
cfg.RegisterServicesFromAssemblyContaining(typeof(GetNewsHandler)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Configuration.AddJsonFile("caching.json");
builder.Services.AddCacheManagerConfiguration(builder.Configuration)
 .AddCacheManager();




builder.Services.AddSingleton<INewsRepository,NewsRepository>();
builder.Services.AddSingleton(x =>
{
    
    var connectionString = builder.Configuration.GetConnectionString("MongoDbConnection");
    return new MongoClient(connectionString);
});



// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


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

