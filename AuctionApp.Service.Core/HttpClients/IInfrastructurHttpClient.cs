namespace AuctionApp.Service.Core.HttpClients
{
    public interface IInfrastructurHttpClient
    {
        public Task<TResponse?> SendRequestAuthApiAsync<TResponse, TRequest>(string request, TRequest? param, HttpMethod httpMethod);

        public Task SendRequestStorageProductApiAsync<TRequest>(string request, TRequest? param, HttpMethod httpMethod);

        public Task<TResponse?> SendRequestStorageProductApiAsync<TResponse>(string request, HttpMethod httpMethod);

        public Task SendRequestStorageProductApiAsync(string request, HttpMethod httpMethod);

        public Task SendRequestBargainingApiAsync<TRequest>(string request, TRequest? param, HttpMethod httpMethod);

        public Task<TResponse?> SendRequestBargainingApiAsync<TResponse>(string request, HttpMethod httpMethod);

        public Task SendRequestBargainingApiAsync(string request, HttpMethod httpMethod);
    }
}
