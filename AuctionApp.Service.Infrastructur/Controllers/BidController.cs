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
        private IHttpClient httpClient;
        private IConfiguration servicesConfiguration;
        private const string nameApi = "BargainingApi";

        public BidController(IHttpClient httpClient, ILogger logger, IConfiguration servicesConfiguration)
        {
            this.httpClient = httpClient;
            this.logger = logger;
            this.servicesConfiguration = servicesConfiguration;
        }

        [HttpPost("newBid")]
        public async Task<ActionResult> NewBidAsync([FromBody] BargainingModel bargainingModel)
        {
            try
            {
                logger.LogInformation($"HTTP: api/Bid/newBid");

                var request = "newBid";

                await httpClient._SendRequestAsync(new RequestModel()
                {
                    BaseAddress = servicesConfiguration[$"URL:{nameApi}"],
                    Request = request,
                    _HttpMethod = HttpMethod.Post
                }, bargainingModel);

                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(BidController)}.NewBidAsync : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
