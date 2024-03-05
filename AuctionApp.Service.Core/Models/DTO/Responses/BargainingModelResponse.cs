using Newtonsoft.Json;

namespace AuctionApp.Service.Core.Models.DTO.Responses
{
    public sealed class BargainingModelResponse
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
