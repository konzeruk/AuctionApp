using AuctionApp.Service.Core.Extensions;
using AuctionApp.Service.Core.Models.DTO;
using AuctionApp.Service.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Service.Bargaining.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BargainingController : ControllerBase
    {
        private ILogger logger;
        private IBargainingEntityRepository repository;

        public BargainingController(ILogger logger, IBargainingEntityRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }

        [HttpPost("newBid")]
        public async Task<ActionResult> NewBidAsync([FromBody] BargainingModel bargainingModel)
        {
            try
            {
                logger.LogInformation($"HTTP: /newBid");

                var bargainingEntity = await repository.GetBargainingEntityAsync(bargainingModel.UserId, bargainingModel.ProductId);

                if(bargainingEntity == null)        
                    await repository.AddBidAsync(bargainingModel.ToBargainingEntity());
                else
                {
                    bargainingEntity.Price = bargainingModel.Price;
                    await repository.UpdataBidAsync(bargainingEntity);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(BargainingController)}.NewBidAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }

        // нужен для получения победителя в ставках
        [HttpGet("getWinBid/{productId:int}")]
        public async Task<ActionResult> GetWinBidAsync([FromRoute] int productId)
        {
            try
            {
                logger.LogInformation($"HTTP: /getWinBid");

                var bargainingEntity = await repository.GetWinBidAsync(productId);

                if (bargainingEntity == null)
                    throw new Exception(ExceptionsBargnainingApi.NotFoundBargnaining);

                return Ok(value: bargainingEntity.ToBargainingModel());
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(BargainingController)}.GetWinBidAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpDelete("deleteBid/{productId:int}")]
        public async Task<ActionResult> DeleteBidAsync([FromRoute] int productId)
        {
            try
            {
                logger.LogInformation($"HTTP: /deleteBid/{productId}");

                if (productId < 0)
                    throw new Exception(ExceptionsBargnainingApi.IncorrectProductId);

                await repository.DeleteBidAsync(productId);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(BargainingController)}.DeleteBidAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
