using AuctionApp.Service.Core.Models.DTO;

namespace AuctionApp.Service.Core.HttpClients
{
    // интерфейс для HttpClient, который используется сервисом Infrastructur (для связи с другими сервисами) и клиентом (для связи с сервисом Infrastructur)
    public interface IHttpClient
    {
        public Task<string?> SendRequestAsync<TRequest>(RequestModel requestModel, TRequest param);

        public Task<string?> SendRequestAsync(RequestModel requestModel);

        public Task _SendRequestAsync<TRequest>(RequestModel requestModel, TRequest param);

        public Task _SendRequestAsync(RequestModel requestModel);
    }
}
