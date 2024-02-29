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
        private const string nameApi = "AuthApi";
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

                var response = await httpClient.SendRequestAsync<string>(new RequestModel()
                {
                    NameApi = nameApi,
                    Request = string.Empty,
                    _HttpMethod = HttpMethod.Get
                });

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
