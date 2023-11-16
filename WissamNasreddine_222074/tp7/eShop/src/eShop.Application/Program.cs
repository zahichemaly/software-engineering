using eShop.Core.Filters;
using eShop.Core.Interfaces;
using eShop.Core.Middlewares;
using eShop.Infrastructure.Data;
using MongoDbGenericRepository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<SwaggerHeadersFilter>();
});

// Services
builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoDbRepository<>));

// MongoDb connection
MongoSettings mongoSettings = new MongoSettings();
builder.Configuration.GetSection(nameof(MongoSettings)).Bind(mongoSettings);
builder.Services.AddScoped<IMongoDbContext, MongoDbContext>(x =>
{
    return new MongoDbContext(mongoSettings.MongoConnection, mongoSettings.MongoDatabaseName);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseForceUpdate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }
