using AuctionApp.Service.Core.Exceptions;
using AuctionApp.Service.Core.Models.DTO.Response;
using AuctionApp.Service.Core.Repositories;
using Microsoft.AspNetCore.Http;

namespace AuctionApp.Service.Auth.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IAuthEntityRepository authEntityRepository;
        private readonly IExceptionApi exception;

        public AuthenticationMiddleware(RequestDelegate next, IAuthEntityRepository authEntityRepository, IExceptionApi exception)
        {
            this.next = next;
            this.authEntityRepository = authEntityRepository;
            this.exception = exception;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var login = context.Request.Query["login"];
            var password = context.Request.Query["password"];

            if (login == string.Empty || password == string.Empty)
            {
                var _exception = exception.IncorrectData();
                context.Response.StatusCode = _exception.Code;
                await context.Response.WriteAsync(_exception.Message);
            }
            else
            {
                var userEntity = await authEntityRepository.GetUser(login, password);
                if(userEntity == null)
                {
                    var _exception = exception.NotFoundEntry();
                    context.Response.StatusCode = _exception.Code;
                    await context.Response.WriteAsync(_exception.Message);
                }
                else
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync(userEntity.Id.ToString());
                    await next.Invoke(context);
                }
            }
        }
    }
}
