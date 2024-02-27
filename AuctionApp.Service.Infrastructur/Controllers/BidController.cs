using AuctionApp.Service.Core.HttpClients;
using AuctionApp.Service.Core.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Service.Infrastructur.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BidController : ControllerBase
    {
        private ILogger logger;
        private IInfrastructurHttpClient httpClient;

        public BidController(IInfrastructurHttpClient httpClient, ILogger logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        [HttpPost("newBid")]
        public async Task<ActionResult> NewBidAsync([FromBody] BargainingModel bargainingModel)
        {
            try
            {
                logger.LogInformation($"HTTP: api/Bid/newBid");

                var request = "newBid";

                await httpClient.SendRequestBargainingApiAsync(request, bargainingModel, HttpMethod.Post);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(BidController)}.NewBidAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpGet("getWinBid/{productId:int}")]
        public async Task<ActionResult> GetWinBidAsync([FromRoute] int productId)
        {
            try
            {
                logger.LogInformation($"HTTP: api/Bid/getWinBid/{productId}");

                var request = $"getWinBid/{productId}";

                var response = await httpClient.SendRequestBargainingApiAsync<BargainingModel>(request, HttpMethod.Get);

                return Ok(value: response);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(BidController)}.GetWinBidAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }

        [HttpDelete("deleteBid/{categoryId:int}")]
        public async Task<ActionResult> DeleteBidAsync([FromRoute] int categoryId)
        {
            try
            {
                logger.LogInformation($"HTTP: api/Bid/deleteBid/{categoryId}");

                var request = $"deleteBid/{categoryId}";

                await httpClient.SendRequestBargainingApiAsync(request, HttpMethod.Delete);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(BidController)}.DeleteBidAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
