using AuctionApp.Service.Core.HttpClients;
using AuctionApp.Service.Infrastructur.Helpers;
using AuctionApp.Service.Infrastructur.HttpClients;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;

services.AddControllers();

services.AddSingleton<ILogger>(s => s.GetService<ILogger<Program>>()!);
services.AddSingleton<IHttpClient, AuctionAppHttpClient>();

var app = builder.Build();

builder.Configuration.AddJsonFile("appsettings.json");

app.UseHttpsRedirection();

app.MapControllers();

var helper = new HelperInfrastructur(app.Services.GetService<IHttpClient>(), app.Services.GetService<ILogger>(), app.Configuration);

helper.CounterStart();

app.Run();
