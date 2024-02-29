using AuctionApp.Service.Core.HttpClients;
using AuctionApp.Service.Core.Models.DTO;
using System.Net;
using System.Text.Json;

namespace AuctionApp.Service.Infrastructur.HttpClients
{
    //переделать это говно
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

        public async Task<TResponse?> SendRequestAsync<TResponse, TRequest>(RequestModel requestModel, TRequest param) 
        {
            try
            {
                logger.LogInformation($"Request to {requestModel.NameApi}");

                var content = CreateJsonContent(param);

                var response = await SendRequestAsync(servicesConfiguration[$"URL:{requestModel.NameApi}"], requestModel._HttpMethod, requestModel.Request, content);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);

                return JsonSerializer.Deserialize<TResponse>(contentResponse);
            }
            catch (Exception)
            {
                logger.LogInformation($"{typeof(InfrastructurHttpClient)}.{requestModel.NameApi}.SendRequestAsync");
                throw;
            }
        }

        public async Task<TResponse?> SendRequestAsync<TResponse>(RequestModel requestModel)
        {
            try
            {
                logger.LogInformation($"Request to {requestModel.NameApi}");

                var response = await SendRequestAsync(servicesConfiguration[$"URL:{requestModel.NameApi}"], requestModel._HttpMethod, requestModel.Request, null);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);

                return JsonSerializer.Deserialize<TResponse>(contentResponse);
            }
            catch (Exception)
            {
                logger.LogInformation($"{typeof(InfrastructurHttpClient)}.{requestModel.NameApi}.SendRequestAsync");
                throw;
            }
        }

        public async Task SendRequestAsync<TRequest>(RequestModel requestModel, TRequest param)
        {
            try
            {
                logger.LogInformation($"Request to {requestModel.NameApi}");

                if (param == null)
                    throw new Exception(ExceptionInfrastructurApi.ErrorRequestAuthApi);

                var content = CreateJsonContent(param);

                var response = await SendRequestAsync(servicesConfiguration[$"URL:{requestModel.NameApi}"], requestModel._HttpMethod, requestModel.Request, content);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);
            }
            catch (Exception)
            {
                logger.LogInformation($"{typeof(InfrastructurHttpClient)}.{requestModel.NameApi}.SendRequestAsync");
                throw;
            }
        }

        public async Task SendRequestAsync(RequestModel requestModel)
        {
            try
            {
                logger.LogInformation($"Request to {requestModel.NameApi}");

                var response = await SendRequestAsync(servicesConfiguration[$"URL:{requestModel.NameApi}"], requestModel._HttpMethod, requestModel.Request, null);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);
            }
            catch (Exception)
            {
                logger.LogInformation($"{typeof(InfrastructurHttpClient)}.{requestModel.NameApi}.SendRequestAsync");
                throw;
            }
        }

        private async Task<HttpResponseMessage> SendRequestAsync(string baseAddress, HttpMethod httpMethod, string request, JsonContent? content)
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
