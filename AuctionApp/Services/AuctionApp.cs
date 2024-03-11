using AuctionApp.Service.Core.HttpClients;
using AuctionApp.Service.Infrastructur.HttpClients;

namespace AuctionApp.Services
{
    internal static partial class AuctionApp
    {
        private static IHttpClient httpClient = new AuctionAppHttpClient();

        // адрес главного сервиса, через который происходит координация
        private const string baseAddress = "http://localhost:7070";
    }
}
