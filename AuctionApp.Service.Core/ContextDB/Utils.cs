using Microsoft.Extensions.Configuration;

namespace AuctionApp.Service.Core.ContextDB
{
    internal static class Utils
    {
        public static string GetConnectionString(string nameDb)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.FullName)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            return configuration.GetConnectionString(nameDb)!;
        }
    }
}
