using AuctionApp.Service.Core.Models.DTO;

namespace AuctionApp.Service.Core.HttpClients
{
    public interface IHttpClient
    {
        public Task<string?> SendRequestAsync<TRequest>(RequestModel requestModel, TRequest param);

        public Task<string?> SendRequestAsync(RequestModel requestModel);

        public Task _SendRequestAsync<TRequest>(RequestModel requestModel, TRequest param);

        public Task _SendRequestAsync(RequestModel requestModel);
    }
}
