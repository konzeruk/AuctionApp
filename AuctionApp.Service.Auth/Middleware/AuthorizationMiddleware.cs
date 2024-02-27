using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json;

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
                // сделать красиво
                using StreamReader reader = new StreamReader(context.Request.Body);
                string json = await reader.ReadToEndAsync();

                var authModel = JsonConvert.DeserializeObject<AuthModel>(json);

                if (authModel == null)
                    throw new Exception(ExpceptionAuthApi.IncorrectData);

                var login = authModel.Login;

                logger.LogInformation($"Authorization: {login}");

                var password = authModel.Password;

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
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(AuthorizationMiddleware)} : {ex.Message}");

                context.Response.StatusCode = 500;
                await context.Response.WriteAsync($"Error: {ex.Message}");
            }
        }
    }
}
