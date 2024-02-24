using AuctionApp.Service.Auth;
using AuctionApp.Service.Auth.Middleware;
using AuctionApp.Service.Auth.Repositories;
using AuctionApp.Service.Core.ContextDB;
using AuctionApp.Service.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddSingleton<ILogger>(s => s.GetService<ILogger<AuthorizationMiddleware>>()!);
services.AddSingleton<ApplicationContextAuth>();
services.AddSingleton<IAuthEntityRepository, AuthEntityRepository>();

var app = builder.Build();

app.UseAuth();

app.Run();
