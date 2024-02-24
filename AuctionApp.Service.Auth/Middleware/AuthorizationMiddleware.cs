using AuctionApp.Service.Core.Repositories;
using Microsoft.Extensions.Logging;

namespace AuctionApp.Service.Auth.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate next;
        private readonly IAuthEntityRepository authEntityRepository;
        private readonly ILogger logger;

        public AuthorizationMiddleware(RequestDelegate next, ILogger logger, IAuthEntityRepository authEntityRepository)
        {
            this.next = next;
            this.authEntityRepository = authEntityRepository;
            this.logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                var login = context.Request.Query["login"];

                logger.LogInformation($"Authorization: {login}");

                var password = context.Request.Query["password"];

                if (login == string.Empty || password == string.Empty)
                    throw new Exception(ExpceptionAuthApi.IncorrectData);
                else
                {
                    var userEntity = await authEntityRepository.GetUserAsync(login, password);

                    if (userEntity == null)
                         throw new Exception(ExpceptionAuthApi.NotFoundUser);
                    else
                    {
                        logger.LogInformation("User found");

                        context.Response.StatusCode = 200;
                        await context.Response.WriteAsync(userEntity.Id.ToString());
                        await next.Invoke(context);
                    }
                }
            }
            catch(Exception ex)
            {
                logger.LogInformation($"{typeof(AuthorizationMiddleware)} : {ex.Message}");

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"Error: {ex.Message}");
            }
        }
    }
}
