using AuctionApp.Service.Core.HttpClients;
using Azure.Core;
using System.Net;
using System.Text.Json;

namespace AuctionApp.Service.Infrastructur.HttpClients
{
    public class InfrastructurHttpClient : IInfrastructurHttpClient
    {
        private HttpClient httpClient;
        private IConfiguration servicesConfiguration;
        private ILogger logger;

        public InfrastructurHttpClient(IConfiguration servicesConfiguration, ILogger logger)
        {
            httpClient = new HttpClient();
            this.servicesConfiguration = servicesConfiguration;
            this.logger = logger;
        }

        public async Task<TResponse?> SendRequestAuthApiAsync<TResponse, TRequest>(string request, TRequest? param, HttpMethod httpMethod) =>
            await SendRequestAsync<TResponse, TRequest>(request, param, "AuthApi", httpMethod);

        public async Task SendRequestBargainingApiAsync<TRequest>(string request, TRequest? param, HttpMethod httpMethod) =>
            await SendRequestAsync(request, param, "BargainingApi", httpMethod);

        public async Task<TResponse?> SendRequestBargainingApiAsync<TResponse>(string request, HttpMethod httpMethod) =>
            await SendRequestAsync<TResponse>(request, "BargainingApi", httpMethod);

        public async Task SendRequestBargainingApiAsync(string request, HttpMethod httpMethod) =>
            await SendRequestAsync(request, "BargainingApi", httpMethod);

        public async Task SendRequestStorageProductApiAsync<TRequest>(string request, TRequest? param, HttpMethod httpMethod) =>
            await SendRequestAsync(request, param, "StorageProductApi", httpMethod);

        public async Task<TResponse?> SendRequestStorageProductApiAsync<TResponse>(string request, HttpMethod httpMethod) =>
            await SendRequestAsync<TResponse>(request, "StorageProductApi", httpMethod);

        public async Task SendRequestStorageProductApiAsync(string request, HttpMethod httpMethod) =>
            await SendRequestAsync(request, "StorageProductApi", httpMethod);

        private async Task<TResponse?> SendRequestAsync<TResponse, TRequest>(string request, TRequest? param, string api, HttpMethod httpMethod)
        {
            try
            {
                logger.LogInformation($"Request to {api}");

                var content = CreateJsonContent(param);

                var response = await _SendRequestAsync(servicesConfiguration[$"URL:{api}"], httpMethod, request, content);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);

                return JsonSerializer.Deserialize<TResponse>(contentResponse);
            }
            catch (Exception)
            {
                logger.LogInformation($"{typeof(InfrastructurHttpClient)}.{api}.SendRequestAsync");
                throw;
            }
        }

        private async Task SendRequestAsync<TRequest>(string request, TRequest? param, string api, HttpMethod httpMethod)
        {
            try
            {
                logger.LogInformation($"Request to {api}");

                if (param == null)
                    throw new Exception(ExceptionInfrastructurApi.ErrorRequestAuthApi);

                var content = CreateJsonContent(param);

                var response = await _SendRequestAsync(servicesConfiguration[$"URL:{api}"], httpMethod, request, content);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);
            }
            catch (Exception)
            {
                logger.LogInformation($"{typeof(InfrastructurHttpClient)}.{api}.SendRequestAsync");
                throw;
            }
        }

        private async Task SendRequestAsync(string request, string api, HttpMethod httpMethod)
        {
            try
            {
                logger.LogInformation($"Request to {api}");

                var response = await _SendRequestAsync(servicesConfiguration[$"URL:{api}"], httpMethod, request, null);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);
            }
            catch (Exception)
            {
                logger.LogInformation($"{typeof(InfrastructurHttpClient)}.{api}.SendRequestAsync");
                throw;
            }
        }

        private async Task<TResponse?> SendRequestAsync<TResponse>(string request, string api, HttpMethod httpMethod)
        {
            try
            {
                logger.LogInformation($"Request to {api}");

                var response = await _SendRequestAsync(servicesConfiguration[$"URL:{api}"], httpMethod, request, null);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);

                return JsonSerializer.Deserialize<TResponse>(contentResponse);
            }
            catch (Exception)
            {
                logger.LogInformation($"{typeof(InfrastructurHttpClient)}.{api}.SendRequestAsync");
                throw;
            }
        }

        private async Task<HttpResponseMessage> _SendRequestAsync(string baseAddress, HttpMethod httpMethod, string request, JsonContent? content)
        {
            try
            {
                logger.LogInformation($"Send request : {baseAddress}/{request}");

                return await httpClient.SendAsync(new HttpRequestMessage
                {
                    RequestUri = new Uri($"{baseAddress}/{request}"),
                    Method = httpMethod,
                    Content = content ?? null
                });

            }
            catch (Exception)
            {
                throw;
            }
        }

        private JsonContent CreateJsonContent<TRequest>(TRequest param) =>
            JsonContent.Create(param);
    }
}
