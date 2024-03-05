using Newtonsoft.Json;

namespace AuctionApp.Service.Core.Models.DTO
{
    public sealed class BargainingModel
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("productId")]
        public int ProductId { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }
    }
}
