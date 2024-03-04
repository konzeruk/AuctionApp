using AuctionApp.Service.Core.Extensions;
using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Models.DTO.Responses;
using AuctionApp.Service.Core.Models.Entities;
using AuctionApp.Service.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Service.StorageProduct.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorageProductController : ControllerBase
    {
        private IProductEntityRepository repository;
        private ILogger logger;

        public StorageProductController(ILogger logger, IProductEntityRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpPost("addProduct/{categoryId:int}")]
        public async Task<ActionResult> AddProductAsync([FromRoute] int categoryId, [FromBody] ProductModel productModel)
        {
            try
            {
                logger.LogInformation($"HTTP: /addProduct/{categoryId}");

                var categoryEntity = await repository.GetCategoryByIdAsync(categoryId);

                if (categoryEntity == null)
                    throw new Exception(ExceptionsStorageProductApi.NotFoundCategoryById);

                var productEntity = new ProductEntity()
                {
                    Name = productModel.Name,
                    Price = productModel.Price,
                    DateEnd = productModel.DateEnd,
                    Category = categoryEntity,
                    CategoryId = categoryEntity.Id
                };

                await repository.AddProductAsync(productEntity);

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
                logger.LogInformation($"HTTP: /updataPriceProduct/{id}");

                if (id < 0)
                    throw new Exception(ExceptionsStorageProductApi.IncorrectId);

                var productEntity = await repository.GetProductAsync(id);

                if (productEntity == null)
                    throw new Exception(ExceptionsStorageProductApi.NotFoundProduct);

                productEntity.Price = price;

                await repository.UpdataProductAsync(productEntity);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(StorageProductController)}.UpdataPriceProductAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpDelete("deleteProduct/{id:int}")]
        public async Task<ActionResult> DeleteProductAsync([FromRoute] int id)
        {
            try
            {
                logger.LogInformation($"HTTP: /deleteProduct/{id}");

                if (id < 0)
                    throw new Exception(ExceptionsStorageProductApi.IncorrectId);

                var productEntity = await repository.GetProductAsync(id);

                if (productEntity == null)
                    throw new Exception(ExceptionsStorageProductApi.NotFoundProduct);

                await repository.DeleteProductAsync(productEntity);

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
                logger.LogInformation($"HTTP: /getAllProduct/{categoryId}");

                if (categoryId < 0)
                    throw new Exception(ExceptionsStorageProductApi.IncorrectId);

                var commandResult = await repository.GetAllProductByCategoryAsync(categoryId);

                if (commandResult == null)
                    throw new Exception(ExceptionsStorageProductApi.NotFoundProductsByCategory);

                var listProductEntity = commandResult.ToList();
                var listProductModel = new List<ProductModelResponse>();
                foreach (var productEntity in listProductEntity)
                    listProductModel.Add(productEntity.ToProductModelResponse());

                return Ok(value: listProductModel);
            }
            catch(Exception ex)
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
                logger.LogInformation($"HTTP: /getAllCategory");

                var commandResult = await repository.GetAllCategoryAsync();

                if(commandResult == null)
                    throw new Exception(ExceptionsStorageProductApi.NotCategory);

                var listCategoryEntity = commandResult.ToList();
                var listCategoryModel = new List<CategoryModel>();
                foreach (var categoryEntity in listCategoryEntity)
                    listCategoryModel.Add(categoryEntity.ToCategoryModel());

                return Ok(value: listCategoryModel);
            }
            catch(Exception ex)
            {

                logger.LogInformation($"{typeof(StorageProductController)}.GetAllCategoryAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
