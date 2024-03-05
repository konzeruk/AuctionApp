using AuctionApp.Service.Core.HttpClients;
using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Models.DTO.Responses;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace AuctionApp.Service.Infrastructur.Helpers
{
    // класс, в котором методы нужны для того, чтобы выявлять победителя в ставках
    // по факту здесь работает задача, которая каждый день в 12 ночи считывает все продукты из бд, после чего проверяет, у какого продукта сегодня заканчивается торг
    // после чего возвращает победную ставку и удаляет продукт из бд и удаляет ставки на этот продукт
    public class HelperInfrastructur
    {
        private ILogger logger;
        private IHttpClient httpClient;
        private IConfiguration servicesConfiguration;

        public HelperInfrastructur(IHttpClient httpClient, ILogger logger, IConfiguration servicesConfiguration)
        {
            this.httpClient = httpClient;
            this.logger = logger;
            this.servicesConfiguration = servicesConfiguration;
        }

        public void CounterStart()=>
            Task.Run(() => CounterDateEndAsync());

        private async Task CounterDateEndAsync()
        {
            await Task.Run(async () =>
            {
                // бесконечный цикл, в котором происходит вся магия
                while (true)
                {
                    try
                    {
                        logger.LogInformation($"Counter date end launch");
                        
                        // узнаём сегодняшнюю дату
                        var date = DateTime.Now;

                        var year = date.Year;
                        var day = date.Day;
                        var month = date.Month;

                        // получаем все продукты из бд
                        var listProductDateModel = await GetAllProductDateAsync();

                        // просматриваем полученный список продуктов
                        foreach (var productDate in listProductDateModel)
                        {
                            // если у продукта сегодня окончавается торг 
                            if(productDate.DateEnd.Day == day && productDate.DateEnd.Month == month && productDate.DateEnd.Year == productDate.DateEnd.Year)
                            {
                                var productId = productDate.Id;

                                // возвращаем победную ставку
                                var bargainingModel = await GetWinBidAsync(productId);

                                // если она конечно есть
                                if (bargainingModel != null)
                                {
                                    // добавляем в хранилище победных ставок
                                    StaticValue.WinBid.Add(new BargainingModelResponse()
                                    {
                                        Name = productDate.Name,
                                        UserId = bargainingModel.UserId
                                    });

                                    // удаляем продукт и ставки с ним связанные
                                    await DeleteProductAsync(productId);

                                    await DeleteBidAsync(productId);
                                }
                            }
                        }

                        // подсчитываем сколько осталось до 12 ночи
                        var hourStartCounter = 23 - date.Hour;
                        var minutStartCounter = 60 - date.Minute;
                        var secondStartCounter = 60 - date.Second;

                        // переводим всё это время в миллисекунды
                        var timeWait = (hourStartCounter * 3600000) + (minutStartCounter * 60000) + (secondStartCounter * 1000); 

                        // останавливаем задачу до 12 ночи
                        await Task.Delay(timeWait);
                    }
                    catch (Exception ex)
                    {
                        logger.LogInformation($"{typeof(HelperInfrastructur)}.CounterDateEndAsync : {ex.Message}");
                    }
                }
            });
        }

        private async Task<BargainingModel?> GetWinBidAsync(int productId)
        {
            try
            {
                logger.LogInformation($"HTTP: api/Bid/getWinBid/{productId}");

                var request = $"getWinBid/{productId}";

                var response = await httpClient.SendRequestAsync(new RequestModel()
                {
                    BaseAddress = servicesConfiguration[$"URL:BargainingApi"],
                    Request = request,
                    _HttpMethod = HttpMethod.Get
                });

                return JsonConvert.DeserializeObject<BargainingModel>(response);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<List<ProductDateModel>?> GetAllProductDateAsync()
        {
            try
            {
                logger.LogInformation($"HTTP: api/StorageProduct/getAllProductDate");

                var request = "getAllProductDate";

                var response = await httpClient.SendRequestAsync(new RequestModel()
                {
                    BaseAddress = servicesConfiguration[$"URL:StorageProductApi"],
                    Request = request,
                    _HttpMethod = HttpMethod.Get
                });

                return JsonConvert.DeserializeObject<List<ProductDateModel>>(response, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteProductAsync(int productId)
        {
            try
            {
                logger.LogInformation($"HTTP: api/StorageProduct/deleteProduct");

                var request = $"deleteProduct/{productId}";

                await httpClient._SendRequestAsync(new RequestModel()
                {
                    BaseAddress = servicesConfiguration[$"URL:StorageProductApi"],
                    Request = request,
                    _HttpMethod = HttpMethod.Delete
                });
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteBidAsync(int productId)
        {
            try
            {
                logger.LogInformation($"HTTP: api/Bid/deleteBid/{productId}");

                var request = $"deleteBid/{productId}";

                await httpClient._SendRequestAsync(new RequestModel()
                {
                    BaseAddress = servicesConfiguration[$"URL:BargainingApi"],
                    Request = request,
                    _HttpMethod = HttpMethod.Delete
                });
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
