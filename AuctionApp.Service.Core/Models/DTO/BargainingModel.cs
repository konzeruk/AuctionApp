using Newtonsoft.Json;

namespace AuctionApp.Service.Core.Models.DTO
{
    public class BargainingModel
    {
        [JsonProperty("user_id")]
        public int UserId { get; set; }

        [JsonProperty("product_id")]
        public int ProductId { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }
    }
}
