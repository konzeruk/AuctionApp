using AuctionApp.Service.Core.ContextDB;
using AuctionApp.Service.Core.Repositories;
using AuctionApp.Service.StorageProduct.Controllers;
using AuctionApp.Service.StorageProduct.Repositories;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddScoped<ILogger>(s => s.GetService<ILogger<StorageProductController>>()!);
services.AddScoped<ApplicationContextProduct>();
services.AddScoped<IProductEntityRepository, ProductEntityRepository>();

services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();
