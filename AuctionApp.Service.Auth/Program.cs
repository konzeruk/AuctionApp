using AuctionApp.Service.Auth;
using AuctionApp.Service.Auth.Middleware;
using AuctionApp.Service.Auth.Repositories;
using AuctionApp.Service.Core.ContextDB;
using AuctionApp.Service.Core.Exceptions;
using AuctionApp.Service.Core.Repositories;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;

service.AddSingleton<ApplicationContextAuth>();
service.AddSingleton<IAuthEntityRepository, AuthEntityRepository>();
service.AddSingleton<IExceptionApi, ExpceptionAuthApi>();

var app = builder.Build();

var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
var logger = loggerFactory.CreateLogger<Program>();

app.UseAuth();

app.Run();
