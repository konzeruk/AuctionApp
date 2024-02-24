using Newtonsoft.Json;

namespace AuctionApp.Service.Core.Models.DTO
{
    public class CategoryModel
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
