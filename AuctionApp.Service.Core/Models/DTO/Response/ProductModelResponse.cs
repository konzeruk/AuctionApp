using AuctionApp.Service.Core.Models.Entities;
using Newtonsoft.Json;

namespace AuctionApp.Service.Core.Models.DTO.Response
{
    public class ProductModelResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public double Price { get; set; }

        [JsonProperty("date_end")]
        public DateTime DateEnd { get; set; }

        [JsonProperty("name_category")]
        public string NameCategory { get; set; }
    }
}
