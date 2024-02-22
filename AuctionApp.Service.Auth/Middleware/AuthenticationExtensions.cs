using AuctionApp.Service.Core.Exceptions;
using AuctionApp.Service.Core.Repositories;

namespace AuctionApp.Service.Auth.Middleware
{
    public static class AuthenticationExtensions
    {
        public static IApplicationBuilder UseAuth(this IApplicationBuilder builder) =>
            builder.UseMiddleware<AuthenticationMiddleware>();
    }
}
