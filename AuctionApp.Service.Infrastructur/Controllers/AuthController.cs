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
        private IHttpClient httpClient;
        private IConfiguration servicesConfiguration;
        private const string nameApi = "AuthApi";
        public AuthController(IHttpClient httpClient, ILogger logger, IConfiguration servicesConfiguration)
        {
            this.httpClient = httpClient;
            this.logger = logger;
            this.servicesConfiguration = servicesConfiguration;
        }

        [HttpGet]
        public async Task<ActionResult> GetUserIdAsync([FromBody] AuthModel authModel)
        {
            try
            {
                logger.LogInformation($"HTTP: api/{typeof(AuthController)}");

                var response = await httpClient.SendRequestAsync(new RequestModel()
                {
                    BaseAddress = servicesConfiguration[$"URL:{nameApi}"],
                    Request = string.Empty,
                    _HttpMethod = HttpMethod.Get
                }, authModel);

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
