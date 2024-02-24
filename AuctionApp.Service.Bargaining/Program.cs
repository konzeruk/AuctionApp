using AuctionApp.Service.Bargaining.Controllers;
using AuctionApp.Service.Bargaining.Repositories;
using AuctionApp.Service.Core.ContextDB;
using AuctionApp.Service.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddScoped<ILogger>(s => s.GetService<ILogger<BargainingController>>()!);
services.AddScoped<ApplicationContextBargaining>();
services.AddScoped<IBargainingEntityRepository, BargainingEntityRepository>();

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
