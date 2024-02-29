using AuctionApp.Service.Core.Models.DTO;

namespace AuctionApp.Service.Core.HttpClients
{
    public interface IInfrastructurHttpClient
    {
        public Task<TResponse?> SendRequestAsync<TResponse, TRequest>(RequestModel requestModel, TRequest param);

        public Task<TResponse?> SendRequestAsync<TResponse>(RequestModel requestModel);

        public Task SendRequestAsync<TRequest>(RequestModel requestModel, TRequest param);

        public Task SendRequestAsync(RequestModel requestModel);
    }
}
