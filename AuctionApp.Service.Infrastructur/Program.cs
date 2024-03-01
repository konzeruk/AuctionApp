using AuctionApp.Service.Core.HttpClients;
using AuctionApp.Service.Infrastructur.HttpClients;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddScoped<ILogger>(s => s.GetService<ILogger<Program>>()!);
services.AddScoped<IHttpClient, AuctionAppHttpClient>();

var app = builder.Build();

builder.Configuration.AddJsonFile("appsettings.json");

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
