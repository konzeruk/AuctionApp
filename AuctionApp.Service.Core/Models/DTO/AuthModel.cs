using Newtonsoft.Json;

namespace AuctionApp.Service.Core.Models.DTO
{
    public class AuthModel
    {
        [JsonProperty("login")]
        public string Login { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
