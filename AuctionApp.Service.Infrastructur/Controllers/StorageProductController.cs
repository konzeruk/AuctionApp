using AuctionApp.Service.Core.HttpClients;
using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Models.DTO.Responses;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Service.Infrastructur.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StorageProductController : ControllerBase
    {
        private ILogger logger;
        private IInfrastructurHttpClient httpClient;
        private const string nameApi = "StorageProductApi";

        public StorageProductController(IInfrastructurHttpClient httpClient, ILogger logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        [HttpPost("addProduct")]
        public async Task<ActionResult> AddProductAsync([FromBody] ProductModel productModel)
        {
            try
            {
                logger.LogInformation($"HTTP: api/StorageProduct/addProduct");

                var request = "addProduct";

                await httpClient.SendRequestAsync(new RequestModel()
                {
                    NameApi = nameApi,
                    Request = request,
                    _HttpMethod = HttpMethod.Post,
                });

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(StorageProductController)}.AddProductAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpPost("updataPriceProduct/{id:int}/{price:double}")]
        public async Task<ActionResult> UpdataPriceProductAsync([FromRoute] int id, [FromRoute] double price)
        {
            try
            {
                logger.LogInformation($"HTTP: api/StorageProduct/updataPriceProduct");

                var request = $"updataPriceProduct/{id}/{price}";

                await httpClient.SendRequestAsync(new RequestModel()
                {
                    NameApi = nameApi,
                    Request = request,
                    _HttpMethod = HttpMethod.Post,
                });

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(StorageProductController).Name}.AddProductAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpDelete("deleteProduct/{id:int}")]
        public async Task<ActionResult> DeleteProductAsync([FromRoute] int id)
        {
            try
            {
                logger.LogInformation($"HTTP: api/StorageProduct/deleteProduct");

                var request = $"deleteProduct/{id}";

                await httpClient.SendRequestAsync(new RequestModel()
                {
                    NameApi = nameApi,
                    Request = request,
                    _HttpMethod = HttpMethod.Delete
                });

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(StorageProductController)}.DeleteProductAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpGet("getAllProduct/{categoryId:int}")]
        public async Task<ActionResult> GetAllProductAsync([FromRoute] int categoryId)
        {
            try
            {
                logger.LogInformation($"HTTP: api/StorageProduct/getAllProduct");

                var request = $"getAllProduct/{categoryId}";

                var response = await httpClient.SendRequestAsync<List<ProductModelResponse>>(new RequestModel()
                {
                    NameApi = nameApi,
                    Request = request,
                    _HttpMethod = HttpMethod.Get
                });

                return Ok(value: response);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(StorageProductController)}.GetAllProductAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpGet("getAllCategory")]
        public async Task<ActionResult> GetAllCategoryAsync()
        {
            try
            {
                logger.LogInformation($"HTTP: api/StorageProduct/getAllCategory");

                var request = "getAllCategory";

                var response = await httpClient.SendRequestAsync<List<CategoryModel>>(new RequestModel()
                {
                    NameApi = nameApi,
                    Request = request,
                    _HttpMethod = HttpMethod.Get
                });

                return Ok(value: response);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(StorageProductController)}.GetAllCategoryAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
