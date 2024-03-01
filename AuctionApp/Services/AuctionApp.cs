using AuctionApp.Service.Core.HttpClients;
using AuctionApp.Service.Infrastructur.HttpClients;

namespace AuctionApp.Services
{
    internal static partial class AuctionApp
    {
        private static IHttpClient httpClient = new AuctionAppHttpClient();

        private const string baseAddress = "https://localhost:7070";
    }
}
