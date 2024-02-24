using Newtonsoft.Json;

namespace AuctionApp.Service.Core.Models.DTO
{
    public class ProductModel
    {
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
