namespace AuctionApp.Service.Auth.Middleware
{
    // по факту нужен для того, чтобы самописный middleware красиво использовать
    public static class AuthenticationExtensions
    {
        public static IApplicationBuilder UseAuth(this IApplicationBuilder builder) =>
            builder.UseMiddleware<AuthorizationMiddleware>();
    }
}
