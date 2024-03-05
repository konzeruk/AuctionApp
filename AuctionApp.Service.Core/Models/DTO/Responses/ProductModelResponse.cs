using AuctionApp.Service.Core.Models.Entities;
using Newtonsoft.Json;

namespace AuctionApp.Service.Core.Models.DTO.Responses
{
    public sealed class ProductModelResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("dateEnd")]
        public DateTime DateEnd { get; set; }
    }
}
