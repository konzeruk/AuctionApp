using AuctionApp.Service.Core.HttpClients;
using AuctionApp.Service.Core.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AuctionApp.Service.Infrastructur.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private ILogger logger;
        private IInfrastructurHttpClient httpClient;
        
        public AuthController(IInfrastructurHttpClient httpClient, ILogger logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> GetUserIdAsync([FromBody] AuthModel authModel)
        {
            try
            {

                logger.LogInformation($"HTTP: api/{typeof(AuthController)}");

                var request = string.Empty;

                var response = await httpClient.SendRequestAuthApiAsync<string, AuthModel>(request, authModel, HttpMethod.Get);

                return Ok(value: response);
            }
            catch (Exception ex)
            {
                logger.LogInformation($"{typeof(AuthController)}.GetUserId : {ex.Message}");

                return Problem(ex.Message, statusCode: 500);
            }
        }
    }
}
