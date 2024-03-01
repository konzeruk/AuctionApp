using AuctionApp.Service.Core.HttpClients;
using AuctionApp.Service.Core.Models.DTO;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace AuctionApp.Service.Infrastructur.HttpClients
{
    public class AuctionAppHttpClient : IHttpClient
    {
        private HttpClient httpClient;

        public AuctionAppHttpClient() =>
            httpClient = new HttpClient();

        public async Task<string?> SendRequestAsync<TRequest>(RequestModel requestModel, TRequest param) 
        {
            try
            {
                var content = CreateJsonContent(param);

                var response = await SendRequestAsync(requestModel.BaseAddress, requestModel._HttpMethod, requestModel.Request, content);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);

                return contentResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string?> SendRequestAsync(RequestModel requestModel)
        {
            try
            {
                var response = await SendRequestAsync(requestModel.BaseAddress, requestModel._HttpMethod, requestModel.Request, null);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);

                return contentResponse;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task _SendRequestAsync<TRequest>(RequestModel requestModel, TRequest param)
        {
            try
            {
                var content = CreateJsonContent(param);

                var response = await SendRequestAsync(requestModel.BaseAddress, requestModel._HttpMethod, requestModel.Request, content);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task _SendRequestAsync(RequestModel requestModel)
        {
            try
            {
                var response = await SendRequestAsync(requestModel.BaseAddress, requestModel._HttpMethod, requestModel.Request, null);

                var contentResponse = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(contentResponse);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<HttpResponseMessage> SendRequestAsync(string baseAddress, HttpMethod httpMethod, string request, JsonContent? content)
        {
            try
            {
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
